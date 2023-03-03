# ZIP Engineering Onboarding Tutorial

This project is for onboarding new engineers to Zip's engineering principles and tech stacks. We will be creating an inventory service and an order service. During this tutorial, you'll be able to see how we create services and how they communicate with each other.

## Step 1
---
* Clone the project to your local repository.
* Open the solution using your preferred IDE
    * Visual Studio (License available)
    * VS Code
    * JetBrains Rider (Reimbursable)

## Step 2
---
* Build out domain objects for the Inventory service
    * Item
* Build out Application services layer
    * Item Inventory service 
* Need to keep track of the number of items we have available.
* Persist the data somewhere. For this step, we can use in-memory data structures.
    * We will introduce the persistant data layer later in the tutorial
* Build an an API to allow another service to get orders
* Build a Restock API to allow the updating of the items in inventory
* Define Commands for performing actions on the domain
* We use CQRS here at Zip.
* We use Mediatr as well within our code base.

## Step 3
---
* Integrate with the Inventory API
    * An Order is comprised of a collection of items.
* Ask the API for the number of items need to satisfy the order
* Set up Swagger
    * We will use Swagger to test the endpoints and trigger the interactions.


### Authors: 
* David Bang (david.bang@zip.co)
