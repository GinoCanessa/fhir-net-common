﻿/* 
 * Copyright (c) 2019, Firely (info@fire.ly) and contributors
 * See the file CONTRIBUTORS for details.
 * 
 * This file is licensed under the BSD 3-Clause license
 * available at https://raw.githubusercontent.com/FirelyTeam/fhir-net-api/master/LICENSE
 */

namespace Hl7.Fhir.Model.Primitives
{
    public enum PartialPrecision
    {
        Year,
        Month,
        Day,
        Hour,
        Minute,
        Second,

        /// <summary>
        /// Milliseconds and fractions
        /// </summary>
        Fraction
    }
}
