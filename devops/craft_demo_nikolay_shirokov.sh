#! /bin/bash

## In this scenario I will use GCP as Cloud provider and GKE cluster for deployment.

#Get auth. credentials for particular cluster in order to manage or deploy.
gcloud container clusters get-credentials ${GKE_CLUSTER} --zone ${ZONE} --project ${PROJECT}

#Deploy a pod with "hello-app" image (application is not exposed, so it can not be accessed).
kubectl run testpod --image=us-docker.pkg.dev/google-samples/containers/gke/hello-app
