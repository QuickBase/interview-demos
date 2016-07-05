QB User App Deployment
===============================
Deploys the user service to Tomcat running inside Vagrant, from Chef Test Kitchen. Provides a search page to test the service with a form.

Please note: the test suite expects that the Maven demo project has already been built.

###Test Kitchen Deployment Context
```shell
https://localhost:8443/demo/
```
Reachable from browser or curl

###Run Test Kitchen Tests
```shell
$ chef exec kitchen verify
```
Runs the Test Kitchen suite, converges the virtual machine and runs Serverspec integration tests