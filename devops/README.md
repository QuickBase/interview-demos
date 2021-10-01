# Scenario
You've been working at the company for more than a year.  You're comfortable with the systems, processes, and people.  There are 50+ Jenkins pipelines which interact with AWS.  You work closely with various Agile teams as well as the security team.  As an experienced engineer, leading the CI/CD best practices at Quickbase, you're asked to suggest a way to implement Docker container scanning across all relevant pipelines.

Since you're familiar with the pipelines, you know that this can be solved in 1 of 2 ways: 1) Edit all the pipelines or 2) Create common methods which all pipelines that build and deploy Docker containers use, and ensure these common methods guarantee that the images are scanned.

You know that this is a lot of upfront work that will pay dividends.  You also know that one of the best ways to show the value of your proposal is through a simple PoC.

In this PoC, you will create a Jenkins pipeline and a shared Groovy method.  The pipeline will call this method.  The method will interact with a cloud provider in some fashion (the building blocks for AWS is provided below).  It doesn't need to accomplish anything of particular value (as we're not expecting you to spend a lot of time on this).

During the Craft Demo, you'll show your PoC and then provide your thoughts on next steps.

In the spirit of saving time, some of the steps are outline below.  Some links to helpful documentation are also provided in the References section below.

# The PoC
## Setup
### Install Jenkins in a Docker Container
* Install, if necessary, [Docker Desktop](https://www.docker.com/products/docker-desktop)
* * Ensure you have `docker-compose` as well
* Download [docker-compose.yaml](docker-compose.yaml)
* Download [Dockerfile](docker-compose.yaml)
* Run `docker compose build`
* Run `docker compose up`
* You'll see Jenkins start up
* * In the logs, you'll see a message similar to the following; you'll need to grab the admin password for later
```
jenkins    | *************************************************************
jenkins    | *************************************************************
jenkins    | *************************************************************
jenkins    | 
jenkins    | Jenkins initial setup is required. An admin user has been created and a password generated.
jenkins    | Please use the following password to proceed to installation:
jenkins    | 
jenkins    | xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
jenkins    | 
jenkins    | This may also be found at: /var/jenkins_home/secrets/initialAdminPassword
jenkins    | 
jenkins    | *************************************************************
jenkins    | *************************************************************
jenkins    | *************************************************************
```
* Open a browser to http://localhost:8080/
* Complete setup, using the default plugins

### Set Up a Git Repo for the Shared Code
You're welcome to use a remote Git repo if you're comfortable doing so.  The instructions below will set up a local repo with the proper directory skeleton required for Jenkins Pipeline plugins.

First, in another window, acquire a shell on your local Jenkins instance:
`docker exec -it jenkins sh`

Now run the following commands inside that shell:
```
git init --bare /var/jenkins_home/repo.git

cd /tmp
git clone /var/jenkins_home/repo.git
cd repo
git config user.name jenkins
git config user.email jenkins@example.com
mkdir -p vars resources/com/example src/com/example
touch resources/com/example/.gitkeep src/com/example/.gitkeep
echo "# Nothing to see here" > vars/test.groovy
git add .
git commit -a -m "initial structure"
git push
```

### Configure Jenkins
* Add this repo as a Global Pipeline Library so that all builds use it

## Create a Pipeline
* Create a new pipeline-style job, using the built-in hello-world template
* Ensure that this job functions and imports the global pipeline library

## Create a Shared Groovy Pipeline Method
* Create a new Groovy class in the appropriate directory in your repo which interacts with a cloud provider.  A stub is provided below to get you started:
```
package com.example

@Grab(group='software.amazon.awssdk', module='ec2', version='2.10.86')
import software.amazon.awssdk.services.ec2.*
import software.amazon.awssdk.services.ec2.model.*
import software.amazon.awssdk.regions.Region;
import software.amazon.awssdk.auth.credentials.*

class Ec2 implements Serializable {
  static def listInstances(def script) {
      script.echo "I should do something interesting here ..."
  }
}
```

## Update Your Pipeline to Call this New Method
* Alter your pipeline to call your new method
* Keep in mind you'll need to provide/configure credentials to connect to your cloud provider

## Bonus Activities
* Store & pass the cloud provider credentials securely
* Deploy a container using shared methods you develop
* Provide automated tests for your shared method

## References
* https://www.jenkins.io/doc/book/pipeline/shared-libraries/
* https://github.com/awsdocs/aws-doc-sdk-examples/tree/master/javav2/example_code
* https://aws.amazon.com/sdk-for-java/

# Presentation
You're now done with your PoC and you set up a meeting with your colleagues to discuss.

* What would you improve, given more time?
* What's the first shared method you'd implement?
* How would you get all the pipelines converted to use this new method?
