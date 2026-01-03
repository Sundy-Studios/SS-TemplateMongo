terraform {
  required_providers {
    sumologic = {
      source  = "SumoLogic/sumologic"
      version = ">= 3.0.0"
    }
  }

  required_version = ">= 1.3.0"
}

provider "sumologic" {
  access_id  = var.sumologic_access_id
  access_key = var.sumologic_access_key
}

resource "sumologic_collector" "collector" {
  name        = "SS-${var.service_name}-Collector"
  description = "Hosted collector for ${var.service_name} service (${var.environment})"
}

resource "sumologic_http_source" "http_source" {
  collector_id       = sumologic_collector.collector.id
  name               = "SS-${var.service_name}-API"
  description        = "Logs from ${var.service_name} service (${var.environment})"
  category           = "SS/${var.service_name}/${var.environment}"

  fields = {
    org         = "Sundy Studio"
    service     = var.service_name
    environment = var.environment
  }
}
