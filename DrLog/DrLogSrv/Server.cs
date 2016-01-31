﻿/*
  Server.cs -- logging server for DrLog 1.1.0, January 24, 2016
 
  Copyright (c) 2013-2016 Kudryashov Andrey aka Dr
 
  This software is provided 'as-is', without any express or implied
  warranty. In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

      1. The origin of this software must not be misrepresented; you must not
      claim that you wrote the original software. If you use this software
      in a product, an acknowledgment in the product documentation would be
      appreciated but is not required.

      2. Altered source versions must be plainly marked as such, and must not be
      misrepresented as being the original software.

      3. This notice may not be removed or altered from any source distribution.

      Kudryashov Andrey <kudryashov.andrey at gmail.com>
 */


using System;
using DrOpen.DrCommon.DrMsgQueue;
using System.Text;
using DrOpen.DrCommon.DrData;
using DrOpen.DrCommon.DrData.Exceptions;

namespace DrOpen.DrCommon.DrLog.DrLogSrv
{
    public class Server : DDManagerMsgQueue, IDisposable
    {

        //
        public Server()
            : base()
        { }

        public Server(DDNode conf)
        {
            var nConditions = GetNodeByPath(conf, SchemaSrv.AttPathToConditions);
            var nProviders = GetNodeByPath(conf, SchemaSrv.AttPathToProviders);
        }

        /// <summary>
        /// returns node by attribute schema name
        /// </summary>
        /// <param name="conf">server configuration node</param>
        /// <param name="attrName">schema attributte name contains path to configuration</param>
        /// <returns></returns>
        private DDNode GetNodeByPath(DDNode conf, string attrName)
        {
            if (!conf.Attributes.Contains(attrName)) throw new DDNodeMissingAttributeExceptions(attrName);
            return conf.GetNode(conf.Attributes.GetValue(attrName, null));
        }


        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
