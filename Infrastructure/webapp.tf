terraform {
  required_version = ">= 0.11" 
  backend "azurerm" {
    storage_account_name = "__terraformstorageaccount__"
    container_name       = "terraform"
    key                  = "addg_terraform.tfstate"
	  access_key  ="__storagekey__"
    features{}
	}
}

provider "azurerm" {
  version = "=2.0.0"
  features {}
}

resource "azurerm_resource_group" "addg" {
  name     = "__addg_resourcegroupname__"
  location = "West Europe"
}

resource "azurerm_sql_server" "addg" {
  name                         = "__sqlservername__"
  resource_group_name          = "${azurerm_resource_group.addg.location}"
  location                     = "${azurerm_resource_group.addg.location}"
  version                      = "12.0"
  administrator_login          = "__sqladminusername__"
  administrator_login_password = "__sqladminpassword__"
}

resource "azurerm_sql_database" "addg" {
  name                = "__databasename__"
  resource_group_name = "${azurerm_resource_group.addg.location}"
  location            = "${azurerm_resource_group.addg.location}"
  server_name         = "${azurerm_sql_server.addg.name}"
}

resource "azurerm_app_service_plan" "addg" {
  name                = "__appserviceplan__"
  location            = "${azurerm_resource_group.addg.location}"
  resource_group_name = "${azurerm_resource_group.addg.name}"

  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "addg_api" {
  name                = "__appservicenameapi__"
  location            = "${azurerm_resource_group.addg.location}"
  resource_group_name = "${azurerm_resource_group.addg.name}"
  app_service_plan_id = "${azurerm_app_service_plan.addg.id}"
  connection_string {
    name  = "AddgContext"
    type  = "SQLServer"
    value = "Server=${azurerm_sql_server.aadg.fully_qualified_domain_name} Integrated Security=SSPI"
  }
}

resource "azurerm_app_service" "addg_web" {
  name                = "__appservicenameweb__"
  location            = "${azurerm_resource_group.addg.location}"
  resource_group_name = "${azurerm_resource_group.addg.name}"
  app_service_plan_id = "${azurerm_app_service_plan.addg.id}"
  app_settings = {
    "APIUrl" = "${azurerm_app_service.addg_api.default_site_hostname}"
  }
}
