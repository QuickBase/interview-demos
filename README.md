##Overview
Our team combines expertise in software engineering and operations. We write code, make use of configuration management tools and deploy services to diverse infrastructure. The code we produce is modular, tested and parameterized to be run in any environment with any set of attributes.

As a potential candidate for our team, we expect you to have experience with writing and deploying web services. We don't expect you to have expertise with all the technologies utilized in this demo, but these frameworks and technologies do reflect the tools that are typically used by our team.

##Demo
As a center of excellence for platform engineering, our team typically works in collaboration with service providers to deploy and manage their services in production. Our team to engineers solutions that make other teams more efficient, and occasionally, we contribute code back to these teams as well. One of the most important components for any web service we deploy is that it offers a valid health check. We need a consistent way to check that all of the services deployed on our platform are available and ready to serve traffic. This leads us to your demo!

For your craft demo, please assist us in adding a health check endpoint to the provided Java web service code and to test that the provided Chef cookbook successfully deploys the application. We expect the following from your demo:

* A new service endpoint located at '/health' that returns an HTTP 200 status and the text 'Health Check OK'.
* Java unit and functional tests to validate the new health check endpoint conforms to these requirements.
* Serverspec integration tests to validate the Tomcat cookbook deploys the application successfully inside a virtual machine provisioned by Test Kitchen and Vagrant. Test Kitchen should be run from Tomcat cookbook directory.

##Build Requirements
* Maven 3+
* JDK 8+
* Vagrant 1.8 +
* ChefDK 0.12+
* bash or Equivalent Shell
* Internet Connectivity for Dependency Management

Please refer to the README files in the Java and Chef projects to confirm how to build, run and deploy the demo service.
