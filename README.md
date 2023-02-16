# NI2S Third Party
This repository contains certain open source third-party software customizations used by the NI2S runtime and component modules.
## Contents
This repository contains the following projects and folders:
#### NI2S.Orleans
[Orleans](https://github.com/dotnet/orleans) is a cross-platform framework for building robust, scalable distributed applications.

Orleans takes familiar concepts like objects, interfaces, async/await, and try/catch and extends them to multi-server environments. For this reason, Orleans has often been selected as distributed .NET environment.

[Modifications](https://github.com/ARWNI2S/NI2S-ThirdParty/blob/main/NI2S.Orleans/README.md) **will be** applied to enable cluster-wide GDESK architecture in Orleans' messaging infrastructure.
```
Root
├───NI2S.Orleans
│   ├───src
│   │   ├───AdoNet
│   │   │   ├───Orleans.Clustering.AdoNet
│   │   │   ├───Orleans.Persistence.AdoNet
│   │   │   ├───Orleans.Reminders.AdoNet
│   │   ├───AWS
│   │   │   ├───Orleans.Clustering.DynamoDB
│   │   │   ├───Orleans.Persistence.DynamoDB
│   │   │   ├───Orleans.Reminders.DynamoDB
│   │   │   ├───Orleans.Streaming.SQS
│   │   ├───Azure
│   │   │   ├───Orleans.Clustering.AzureStorage
│   │   │   ├───Orleans.GrainDirectory.AzureStorage
│   │   │   ├───Orleans.Hosting.AzureCloudServices
│   │   │   ├───Orleans.Persistence.AzureStorage
│   │   │   ├───Orleans.Reminders.AzureStorage
│   │   │   ├───Orleans.Streaming.AzureStorage
│   │   │   ├───Orleans.Streaming.EventHubs
│   │   │   ├───Orleans.Transactions.AzureStorage
│   │   ├───BootstrapBuild
│   │   │   └───Orleans.CodeGenerator.MSBuild.Bootstrap
│   │   ├───Orleans.Analyzers
│   │   ├───Orleans.BroadcastChannel
│   │   ├───Orleans.Client
│   │   ├───Orleans.Clustering.Consul
│   │   ├───Orleans.Clustering.ZooKeeper
│   │   ├───Orleans.CodeGenerator
│   │   ├───Orleans.CodeGenerator.MSBuild
│   │   ├───Orleans.Connections.Security
│   │   ├───Orleans.Core
│   │   ├───Orleans.Core.Abstractions
│   │   ├───Orleans.EventSourcing
│   │   ├───Orleans.Hosting.Kubernetes
│   │   ├───Orleans.Persistence.Memory
│   │   ├───Orleans.Reminders
│   │   ├───Orleans.Reminders.Abstractions
│   │   ├───Orleans.Runtime
│   │   ├───Orleans.Sdk
│   │   ├───Orleans.Serialization
│   │   ├───Orleans.Serialization.Abstractions
│   │   ├───Orleans.Serialization.NewtonsoftJson
│   │   ├───Orleans.Serialization.SystemTextJson
│   │   ├───Orleans.Serialization.TestKit
│   │   ├───Orleans.Server
│   │   ├───Orleans.Streaming
│   │   ├───Orleans.Streaming.Abstractions
│   │   ├───Orleans.Streaming.GCP
│   │   ├───Orleans.TestingHost
│   │   ├───Orleans.Transactions
│   │   ├───Orleans.Transactions.TestKit.Base
│   │   ├───Orleans.Transactions.TestKit.xUnit
│   │   ├───Redis
│   │   │   ├───Orleans.Clustering.Redis
│   │   │   ├───Orleans.GrainDirectory.Redis
│   │   │   ├───Orleans.Persistence.Redis
│   │   │   └───Orleans.Reminders.Redis
│   │   └───Serializers
│   │       ├───Orleans.Serialization.Protobuf
│   │       └───Orleans.Serialization.ProtobufNet
│   └───test
```
#### NI2S.Orleans.Dashboard
A [dashboard for Microsoft Orleans](https://github.com/OrleansContrib/OrleansDashboard) which provides some simple metrics and insights into what is happening inside your [Orleans](https://github.com/dotnet/orleans) appliction. The dashboard is simple to set up and is designed as a convenience for developers to use whilst building Orleans applications.

[Modifications](https://github.com/ARWNI2S/NI2S-ThirdParty/blob/main/NI2S.Orleans.Dashboard/readme.md) **will be** applied to be used as starting point for in premises monitoring system.
```
Root
├───NI2S.Orleans.Dashboard
│   ├───OrleansDashboard
│   ├───OrleansDashboard.Core
│   ├───OrleansDashboard.EmbeddedAssets
│   └───Tests
```
#### RDFSharp
[RDFSharp](https://github.com/mdesalvo/RDFSharp) is modular layered API for create and manage **RDF models** and **RDF stores**, exchange them using standard **RDF formats**, create and validate **SHACL shapes**, store RDF data on many supported providers, create and execute **SPARQL queries** and **SPARQL operations** on graphs, stores and endpoints.

[Modifications](https://github.com/ARWNI2S/NI2S-ThirdParty/blob/main/RDFSharp/README.md) **will be** applied to be integrated in many ways inside core engine.
```
Root
├───RDFSharp
│   ├───RDFSharp
│   ├───RDFSharp.Test
│   └───TestResults
```
#### RDFSharp.Extensions
This is a set of [RDFSharp](https://github.com/mdesalvo/RDFSharp) extensions suited for storing RDF data on many providers.

[Modifications](https://github.com/ARWNI2S/NI2S-ThirdParty/blob/main/RDFSharp/RDFSharp.Extensions/README.md) **will be** applied to be integrated in many ways inside core engine.
```
Root
├───RDFSharp
│   └───RDFSharp.Extensions
│       ├───RDFSharp.Extensions.AzureTable
│       ├───RDFSharp.Extensions.Firebird
│       ├───RDFSharp.Extensions.MySQL
│       ├───RDFSharp.Extensions.Oracle
│       ├───RDFSharp.Extensions.PostgreSQL
│       ├───RDFSharp.Extensions.SQLite
│       └───RDFSharp.Extensions.SQLServer
```
#### RDFSharp.Semantics
This is an additional [RDFSharp](https://github.com/mdesalvo/RDFSharp) layer expressively suited for creating **OWL-DL ontologies**, validating them against an extensible set of intelligent semantic rules analyzing **T-BOX** and **A-BOX**, and creating **OWL-DL/SWRL reasoners** with **forward-chaining** inference materialization capabilities.

[Modifications](https://github.com/ARWNI2S/NI2S-ThirdParty/blob/main/RDFSharp/RDFSharp.Semantics/README.md) **will be** applied to be integrated in many ways inside core engine.
```
Root
├───RDFSharp
│   └───RDFSharp.Semantics
│       ├───RDFSharp.Semantics
│       └───RDFSharp.Semantics.Test
```