﻿using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// The following GUID is for the ID of the typelib if this project is exposed to COM

[assembly: CLSCompliant(true)]
[assembly: InternalsVisibleTo("Hl7.Fhir.R4.Core")]
[assembly: InternalsVisibleTo("Hl7.Fhir.STU3.Core")]


#if DEBUG
[assembly: InternalsVisibleTo("Hl7.Fhir.Core.Tests")]
#endif