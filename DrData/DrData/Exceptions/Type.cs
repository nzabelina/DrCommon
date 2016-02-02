﻿/*
  Type.cs -- stored node type exceptions for DrData, January 24, 2016
  
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

namespace DrOpen.DrCommon.DrData.Exceptions
{
    /// <summary>
    /// DrData -- type exception
    /// </summary>
    public class DDTypeExceptions : Exception
    {
        public const string NullTypeName = "null";
        /// <summary>
        /// DrData type exception
        /// <param name="name">Type name</param>
        /// </summary>
        public DDTypeExceptions(string name)
            : base() { this.TypeName = name; }
        /// <summary>
        /// DrData type exception
        /// </summary>
        /// <param name="name">Type name</param>
        /// <param name="message">A message that describes the error.</param>
        public DDTypeExceptions(string name, string message)
            : base(message) { this.TypeName = name; }
        /// <summary>
        /// DrData type exception
        /// </summary>
        /// <param name="name">Type name</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeExceptions(string name, string message, Exception innerException)
            : base(message, innerException) { this.TypeName = name; }
        /// <summary>
        /// Name of type
        /// </summary>
        public virtual string TypeName { get; private set; }
    }


    public class DDTypeNullExceptions : DDTypeExceptions
    {
        /// <summary>
        /// Initializes a new instance of the DDTypeNullExceptions class without error message. The type name is "null".
        /// </summary>
        public DDTypeNullExceptions()
            : base(NullTypeName) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeNullExceptions class with the specified error message. The type name is "null".
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        public DDTypeNullExceptions(string message)
            : base(NullTypeName, message) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeNullExceptions class with the specified error message. The type name is "null".
        /// </summary>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeNullExceptions(string message, Exception innerException)
            : base(NullTypeName, message, innerException) { }
    }
    /// <summary>
    /// 
    /// </summary>
    public class DDTypeConvertExceptions : DDTypeExceptions
    {
        /// <summary>
        /// Initializes a new instance of the DDTypeConvertExceptions class without error message.
        /// <param name="currentType">current type name</param>
        /// <param name="requestedTypeName">requested type name</param>
        /// </summary>
        public DDTypeConvertExceptions(string currentType, string requestedTypeName)
            : base(currentType) { this.RequestedTypeName = requestedTypeName; }
        /// <summary>
        /// Initializes a new instance of the DDTypeConvertExceptions class with the specified error message.
        /// <param name="currentType">current type name</param>
        /// <param name="requestedTypeName">requested type name</param>
        /// <param name="message">A message that describes the error.</param>
        /// </summary>
        public DDTypeConvertExceptions(string currentType, string requestedTypeName, string message)
            : base(currentType, message) { this.RequestedTypeName = requestedTypeName; }
        /// <summary>
        /// Initializes a new instance of the DDTypeConvertExceptions class with the specified error message.
        /// </summary>
        /// <param name="currentType">current type name</param>
        /// <param name="requestedTypeName">requested type name</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeConvertExceptions(string currentType, string requestedTypeName, string message, Exception innerException)
            : base(currentType, message, innerException) { this.RequestedTypeName = requestedTypeName; }
        /// <summary>
        /// requested type name
        /// </summary>
        public virtual string RequestedTypeName { get; private set; }
    }
 


    /// <summary>
    /// DrData -- type exception
    /// </summary>
    public class DDTypeIncorrectExceptions : DDTypeExceptions
    {
        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the default error message.
        /// <param name="name">Type name</param>
        /// </summary>
        public DDTypeIncorrectExceptions(string name)
            : base(name, string.Format(Res.Msg.OBJ_TYPE_IS_INCORRECT, name)) { }

        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the default error message.
        /// <param name="type">Type</param>
        public DDTypeIncorrectExceptions(Type type)
            : this((type == null ? NullTypeName : type.Name)) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the specified error message.
        /// </summary>
        /// <param name="name">Type name</param>
        /// <param name="message">A message that describes the error.</param>
        public DDTypeIncorrectExceptions(string name, string message)
            : base(name, message) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the specified error message.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="message">A message that describes the error.</param>
        public DDTypeIncorrectExceptions(Type type, string message)
            : this((type == null ? NullTypeName : type.Name), message) { }

        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the default error message.
        /// </summary>
        /// <param name="name">Type name</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeIncorrectExceptions(string name, Exception innerException)
            : base(name, string.Format(Res.Msg.OBJ_TYPE_IS_INCORRECT, name), innerException) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the default error message.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeIncorrectExceptions(Type type, Exception innerException)
            : this((type == null ? NullTypeName : type.Name), innerException) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the specified error message.
        /// </summary>
        /// <param name="name">Type name</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeIncorrectExceptions(string name, string message, Exception innerException)
            : base(name, message, innerException) { }
        /// <summary>
        /// Initializes a new instance of the DDTypeIncorrectExceptions class with the specified error message.
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="message">A message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception. If the innerException parameter is not a null reference, the current exception is raised in a catch block that handles the inner exception.</param>
        public DDTypeIncorrectExceptions(Type type, string message, Exception innerException)
            : this((type == null ? NullTypeName : type.Name), message, innerException) { }
    }
}
