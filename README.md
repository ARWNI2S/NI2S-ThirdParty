# NI2S Third Party
This repository contains certain open source third-party software customizations used by the NI2S runtime and component modules.

## Contents
This repository contains the following projects and folders:

### NI2S.Orleans
Port from Microsoft orleans bla bla bla...

#### NI2S.Orleans
Port from Microsoft orleans bla bla bla...

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
│       ├───Analyzers.Tests
│       ├───Benchmarks
│       ├───DefaultCluster.Tests
│       ├───DependencyInjection.Tests
│       ├───DistributedTests
│       ├───Extensions
│       │   ├───AWSUtils.Tests
│       │   ├───Consul.Tests
│       │   ├───GoogleUtils.Tests
│       │   ├───ServiceBus.Tests
│       │   ├───Tester.Redis
│       │   ├───TesterAdoNet
│       │   ├───TesterAzureUtils
│       │   └───TesterZooKeeperUtils
│       ├───Grains
│       │   ├───BenchmarkGrainInterfaces
│       │   ├───BenchmarkGrains
│       │   ├───TestFSharp
│       │   ├───TestFSharpGrainInterfaces
│       │   ├───TestGrainInterfaces
│       │   ├───TestGrains
│       │   ├───TestInternalGrainInterfaces
│       │   ├───TestInternalGrains
│       │   ├───TestVersionGrains
│       │   └───TestVersionGrains2
│       ├───Misc
│       │   ├───TestFSharpInterfaces
│       │   ├───TestInterfaces
│       │   └───TestInternalDtosRefOrleans
│       ├───NonSilo.Tests
│       ├───Orleans.Connections.Security.Tests
│       ├───Orleans.Serialization.UnitTests
│       ├───Tester
│       ├───TesterInternal
│       ├───TestInfrastructure
│       │   ├───Orleans.TestingHost.Tests
│       │   └───TestExtensions
│       └───Transactions
│           ├───Orleans.Transactions.Azure.Test
│           └───Orleans.Transactions.Tests
├───NI2S.Orleans.Dashboard
│   ├───OrleansDashboard
│   ├───OrleansDashboard.Core
│   ├───OrleansDashboard.EmbeddedAssets
│   └───Tests
│       ├───PerformanceTests
│       ├───TestGrains
│       ├───TestHosts
│       │   ├───TestHost
│       │   ├───TestHostCohosted2
│       │   └───TestHostSeparate
│       └───UnitTests
└───RDFSharp
    ├───RDFSharp
    ├───RDFSharp.Extensions
    │   ├───RDFSharp.Extensions.AzureTable
    │   ├───RDFSharp.Extensions.Firebird
    │   ├───RDFSharp.Extensions.MySQL
    │   ├───RDFSharp.Extensions.Oracle
    │   ├───RDFSharp.Extensions.PostgreSQL
    │   ├───RDFSharp.Extensions.SQLite
    │   └───RDFSharp.Extensions.SQLServer
    ├───RDFSharp.Semantics
    │   ├───RDFSharp.Semantics
    │   └───RDFSharp.Semantics.Test
    ├───RDFSharp.Test
    └───TestResults
```


### NI2S.Orleans

### NI2S.Orleans.Dashboard

### NI2S.Orleans