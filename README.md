An Amazon Simple Notification Service (SNS) for Event Store

The client periodically subscribes a predefined queue to all topics then saves messages to Event Store, basically an Audit Service for messages being sent via SNS

You need to add your AWS key and secret key to the app.config to allow the client to communicate with AWS

This repo is still in its early days. Ideally I would like to get the client working as a windows service which is why Topshelf is referenced.

Of course anyone is welcome to contribute and ideas are always welcome :) 
