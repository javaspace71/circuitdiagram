﻿// Circuit Diagram http://www.circuit-diagram.org/
// 
// Copyright (C) 2018  Samuel Fisher
// 
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using CircuitDiagram.TypeDescriptionIO.Xml.Logging;

namespace CircuitDiagram.TypeDescriptionIO.Xml
{
    public static class XElementExtensions
    {
        public static bool GetAttribute(this XElement element, string name, IXmlLoadLogger logger, out XAttribute attr)
        {
            attr = element.Attribute(name);
            if (attr == null)
            {
                logger.LogError(element, $"Missing attribute '{name}' for <{element.Name.LocalName}> tag");
                return false;
            }

            return true;
        }

        public static bool GetAttributeValue(this XElement element, string name, IXmlLoadLogger logger, out string value)
        {
            if (element.GetAttribute(name, logger, out var attribute))
            {
                value = attribute.Value;
                return true;
            }

            value = null;
            return false;
        }
    }
}
