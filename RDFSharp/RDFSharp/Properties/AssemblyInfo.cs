﻿/*
   Copyright 2012-2022 Marco De Salvo

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

     http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.
*/

using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
[assembly: ComVisible(false)]
[assembly: Guid("1EF76FD3-C935-4965-9621-6CA0CBC275BF")]
//Internals
[assembly: InternalsVisibleTo("RDFSharp.Extensions.SQLServer")]
[assembly: InternalsVisibleTo("RDFSharp.Extensions.SQLite")]
[assembly: InternalsVisibleTo("RDFSharp.Extensions.Firebird")]
[assembly: InternalsVisibleTo("RDFSharp.Extensions.MySQL")]
[assembly: InternalsVisibleTo("RDFSharp.Extensions.PostgreSQL")]
[assembly: InternalsVisibleTo("RDFSharp.Extensions.Oracle")]
[assembly: InternalsVisibleTo("RDFSharp.Extensions.AzureTable")]
[assembly: InternalsVisibleTo("RDFSharp.Semantics")]
[assembly: InternalsVisibleTo("RDFSharp.Test")]