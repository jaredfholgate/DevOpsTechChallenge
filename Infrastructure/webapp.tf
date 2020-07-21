terraform {
  required_version = ">= 0.11" 
  backend "azurerm" {
    storage_account_name = "__terraformstorageaccount__"
    container_name       = "terraform"
    key                  = "dotc_terraform.tfstate"
	  access_key  ="__storagekey__"
    features{}
	}
}

provider "azurerm" {
  version = "=2.0.0"
  features {}
}

resource "azurerm_resource_group" "dotc" {
  name     = "__dotc_resourcegroupname__"
  location = "__azurelocation__"
}

resource "azurerm_sql_server" "dotc" {
  name                         = "__sqlservername__"
  resource_group_name          = azurerm_resource_group.dotc.location
  location                     = azurerm_resource_group.dotc.location
  version                      = "12.0"
  administrator_login          = "__sqladminusername__"
  administrator_login_password = "__sqladminpassword__"
}

resource "azurerm_sql_database" "dotc" {
  name                = "__databasename__"
  resource_group_name = azurerm_resource_group.dotc.location
  location            = azurerm_resource_group.dotc.location
  server_name         = azurerm_sql_server.dotc.name
}

resource "azurerm_app_service_plan" "dotc" {
  name                = "__appserviceplan__"
  location            = azurerm_resource_group.dotc.location
  resource_group_name = azurerm_resource_group.dotc.name

  sku {
    tier = "Free"
    size = "F1"
  }
}

resource "azurerm_app_service" "dotc_api" {
  name                = "__appservicenameapi__"
  location            = azurerm_resource_group.dotc.location
  resource_group_name = azurerm_resource_group.dotc.name
  app_service_plan_id = azurerm_app_service_plan.dotc.id
  connection_string {
    name  = "dotcContext"
    type  = "SQLServer"
    value = "Server=${azurerm_sql_server.dotc.fully_qualified_domain_name} Integrated Security=SSPI"
  }
}

resource "azurerm_app_service" "dotc_web" {
  name                = "__appservicenameweb__"
  location            = azurerm_resource_group.dotc.location
  resource_group_name = azurerm_resource_group.dotc.name
  app_service_plan_id = azurerm_app_service_plan.dotc.id
  app_settings = {
    "APIUrl" = "${azurerm_app_service.dotc_api.default_site_hostname}"
  }
}
