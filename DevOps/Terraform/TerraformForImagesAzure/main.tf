terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "=3.75.0"
    }
  }
}

provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "rg" {
  name     = "libraryrg"
  location = "West Europe"
}

resource "azurerm_storage_account" "example" {
  name                     = "sandlibraly"
  resource_group_name      = azurerm_resource_group.rg.name
  location                 = azurerm_resource_group.rg.location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  tags = {
    environment = "staging"
  }
}

resource "azurerm_storage_share" "example" {
  name                 = "sandsharename"
  storage_account_name = azurerm_storage_account.example.name
  quota                = 50
}

resource "azurerm_container_group" "example" {
  name                = "sandlibralycg"
  location            = azurerm_resource_group.rg.location
  resource_group_name = azurerm_resource_group.rg.name
  ip_address_type     = "Public"
  dns_name_label      = "sandlibrarydns"
  os_type             = "Linux"

  container {
    name   = "web-app"
    image  = "sand82/library"
    cpu    = "0.5"
    memory = "1.5"

    ports {
      port     = 80
      protocol = "TCP"
    }
  }

  container {
    name   = "sqlserver"
    image  = "mcr.microsoft.com/mssql/server"
    cpu    = "2"
    memory = "2"

    ports {
      port     = 1433
      protocol = "TCP"
    }

    environment_variables = {
      "MSSQL_SA_PASSWORD" = "yourStrongPassword12#",
      "ACCEPT_EULA"       = "Y",
    }

    volume {
      name       = "database-storage-sand"
      mount_path = "/var/opt/mssql"

      read_only  = false
      share_name = azurerm_storage_share.example.name

      storage_account_name = azurerm_storage_account.example.name
      storage_account_key  = azurerm_storage_account.example.primary_access_key
    }
  }
}