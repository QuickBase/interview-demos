#! /bin/bash

## In this scenario I will use GCP as Cloud provider and GKE cluster for deployment.

#Use service account to authorize access
gcloud auth activate-service-account --key-file $SERVICE_ACCOUNT_KEY

#Let assume that the project is alredy created.
#Set up project, zone and region in order to deploy .
gcloud config set project $PROJECT &&
gcloud config set compute/zone $ZONE &&
gcloud config set compute/region $REGION

#Create new cluster with 2 nodes
gcloud container clusters create $GKE_CLUSTER --num-nodes=2

#Get auth. credentials for particular cluster in order to manage or deploy.
gcloud container clusters get-credentials $GKE_CLUSTER 

#Create namespace 
kubectl create namespace $NAMESPACE

#Create Deployment a with 3 replicas in namespace "app"
kubectl create deployment $DEPL_NAME --image=us-docker.pkg.dev/google-samples/containers/gke/hello-app:2.0 --namespace=$NAMESPACE --replicas=3

# Check if newly created pod exists.
POD_VAR=$(kubectl get pods | awk '{print $1}' | grep $DEPL_NAME )
POD_STATUS=$(kubectl get pods | grep $DEPL_NAME | awk '{print $3}' )
if [[ $POD_VAR == $DEPL_NAME && $POD_STATUS == "Running" ]]; then 
      echo "Check was successful"
else     
      echo "Issue with pod deployment"
      exit 1
fi     

#Expose deployment to external traffic on port 443 . Traffic will goes to 8080 port of application
kubectl expose deployment $DEPL_NAME --type LoadBalancer --port 443 --target-port 8080


############### PLAN ###################

#- What type of steps you would perform in order to verify the deployment is successful?

# I already added a short condition to check if the pod can be found by name and its status should be "Running" but this should catch more than one strings and condition would not work if there are more than one pod.
# Best solution I think is to use jsonpath outoput to filter by value , but I need more time to check that .
# Another way is to check what is the command execution status, but this would not help if the pod crash.

#  if [ $? != 0 ]; then 
#    exit 1 
#  fi 

#This can be implemented for every command (just in case)  

#- Plan and a task break-down how you would implement monitoring of this deployed app

#1. Metrics to monitor:
   #- resource metrics (memory,CPU,disk space)
   #- container metrics
   #- application metrics
   #- running/failed pods 

#2. Set up proper Labels 
 
#3. DaemonSets

#4. Set up 3rd party tool for logging and monitoring such as ELK Stack , Prometheus, Datadog or use Cloud provider solutions.

#- What kind of security policies and scans would you recommend to put into place?

#1. Namespaces 

#2. Role-based access control

#2. Resource quotas 

#3. Permissions

#4. Ingress/TLS

#5. Pod Security Policy

#6. IAM

#- What other improvements would you make to the CI/CD process if you had more time?

#- Create pipeline to build image with new code changes.
#- Test new changes on different cluster environments (dev,stage,pre-production).
#- It is good to have snapshots of application/cluster to recover in case of failure.
#- Rolling update deployment or Blue-green deployment scenario.
#- Fast rollback plan in case of failure on production stage.

## - Are there any other good dev-ops tools and practices that you recommend?
#- Terraform 
#- Ansible
#- Helm
#- Jenkins
#- Pod Autoscaling







