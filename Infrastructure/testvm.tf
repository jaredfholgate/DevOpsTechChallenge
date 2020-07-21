resource "azurerm_resource_group" "testvm" {
    name     = "__testvm_resourcegroupname__"
    location = "__azurelocation__"
}

resource "azurerm_virtual_network" "testvm" {
    name                = "example-network"
    address_space       = ["10.0.0.0/16"]
    location            = azurerm_resource_group.testvm.location
    resource_group_name = azurerm_resource_group.testvm.name
}

resource "azurerm_subnet" "testvm" {
    name                 = "internal"
    resource_group_name  = azurerm_resource_group.testvm.name
    virtual_network_name = azurerm_virtual_network.testvm.name
    address_prefix       = "10.0.2.0/24"
}

resource "azurerm_network_interface" "testvm" {
    name                = "example-nic"
    location            = azurerm_resource_group.testvm.location
    resource_group_name = azurerm_resource_group.testvm.name

ip_configuration {
    name                          = "internal"
    subnet_id                     = azurerm_subnet.testvm.id
    private_ip_address_allocation = "Dynamic"
    }
}

resource "azurerm_windows_virtual_machine" "testvm" {
    name                = "example-machine"
    resource_group_name = azurerm_resource_group.testvm.name
    location            = azurerm_resource_group.testvm.location
    size                = "Standard_F2"
    admin_username      = "adminuser"
    admin_password      = "P@$$w0rd1234!"
    network_interface_ids = [
        azurerm_network_interface.testvm.id,
    ]

    os_disk {
        caching              = "ReadWrite"
        storage_account_type = "Standard_LRS"
    }

    source_image_reference {
        publisher = "MicrosoftWindowsServer"
        offer     = "WindowsServer"
        sku       = "2016-Datacenter"
        version   = "latest"
    }
}
