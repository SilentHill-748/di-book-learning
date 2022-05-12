using ClearDIExample;

using System.Security.Principal;

IMessageWriter writer = new ConsoleMessageWriter();
var salutation = new Salutation(writer);
salutation.Exclaim();


IMessageWriter writer2 = new SecureMessageWriter(
    new ConsoleMessageWriter(),
    WindowsIdentity.GetCurrent());

var salutation2 = new Salutation(writer2);
salutation2.Exclaim();