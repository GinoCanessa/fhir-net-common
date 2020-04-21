﻿/* 
 * Copyright (c) 2019, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/fhir-net-api/master/LICENSE
 */


using Hl7.Fhir.ElementModel;
using Hl7.Fhir.Utility;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hl7.Fhir.Validation.Schema
{
    public class ReferenceAssertion : IAssertion, IGroupValidatable
    {
        private readonly Uri _referencedUri;

        public ReferenceAssertion(IElementSchema schema, Uri reference = null)
        {
            _reference = new Lazy<IElementSchema>(() => schema);
            _referencedUri = reference;
        }

        public ReferenceAssertion(Func<IElementSchema> dereference, Uri reference = null)
        {
            _reference = new Lazy<IElementSchema>(dereference);
            _referencedUri = reference;
        }

        private readonly Lazy<IElementSchema> _reference;

        public IElementSchema ReferencedSchema => _reference.Value;
        public Uri ReferencedUri => _referencedUri ?? ReferencedSchema.Id;

        // TODO: Risk of loop (if a referenced schema refers back to this schema - which is nonsense, but possible)
        //public IEnumerable<Assertions> Collect() => ReferencedSchema.Collect();

        public Task<Assertions> Validate(IEnumerable<ITypedElement> input, ValidationContext vc)
            => ReferencedSchema.Validate(input, vc);

        public JToken ToJson() => new JProperty("$ref", ReferencedUri?.ToString() ??
            throw Error.InvalidOperation("Cannot convert to Json: reference refers to a schema without an identifier"));
    }
}