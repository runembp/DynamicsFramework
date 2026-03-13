Notice that the Microsoft.CrmSdk.CoreAssemblies is on purpose kept to version 8.2.0.2, as this is the latest version that Dynamics CRM 2016 supports, which is the main system I am working on.
When it comes to creating Plugins on the environment, if you use a version higher than this (9.x.x) or higher, the plugin can be uploaded, but an exception will be thrown when the Step is being executed.

Simply update the nuget package to a newer version if you're running on Cloud, and this won't be a problem for you.

It looks something like this:

<img width="521" height="259" alt="image" src="https://github.com/user-attachments/assets/d6d224a1-cb3c-4ba2-88f0-e3c8e212d0c3" />
<img width="1172" height="547" alt="image" src="https://github.com/user-attachments/assets/d309e9a3-935b-4a3b-b545-99d214542287" />