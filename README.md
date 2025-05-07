# SkillSearch

A lightweight .NET Core Web API that uses ElasticSearch to index and search a dataset of learning resources (e.g., programming guides, educational materials, classic literature).

## 🔍 Features

- Index resources from a local JSON file into ElasticSearch
- Full-text search on title and description
- Tag-based aggregation (faceted search)
- Simple REST API built with ASP.NET Core
- Compatible with ElasticSearch 7.x+

## 📦 Tech Stack

- .NET 8
- ASP.NET Core Web API
- ElasticSearch 7.17 (via Docker)
- NEST (ElasticSearch .NET client)

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- [Git](https://git-scm.com/)

### Run ElasticSearch (Docker)

```bash
docker-compose up -d
