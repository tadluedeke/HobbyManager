# HobbyManager
>An Asp.NET Web MVC for scale modeling, miniature wargaming, and other hobby painting project management. It allows users to add their paint collection, and record the paints and the order they were used for different colors or projects.

## Table of Contents
* [Database](#database)
* [Features](#features)
* [Planning](#planning)
* [Stretch Goals](#stretch-goals)
* [Schedule](#schedule)
* [Created By](#created-by)
* [Screenshots](#screenshots)
* [Instructions](#instructions)
* [Links](#links)

## Database
![DB Diagram](https://github.com/tadluedeke/HobbyManager/blob/master/images/DbDiagramHobbyManager.PNG)

**Table 1: Model**

        ModelId - int (Primary Key) (Many-to-Many with Project, using ProjectModel as a joining table)
        
        OwnerId - Guid
        
        Name - string
        
        Scale - string
        
        Brand - string
        
**Table 2: Paint**
         
         PaintId - int (Primary Key)
         
         OwnerId - Guid
         
         Brand - string
         
         Name - string
         
         Color - string
         
         SKU - string
         
         Primers - virtual ICollection<Workflow>
         
         BaseCoat - virutal ICollection<Workflow>
         
         Shade - virtual ICollection<Workflow>
         
         HighlightOne - virtual ICollection<Workflow>
         
         SecondHighlight - virtual ICollection<Workflow>
         
**Table 3: Project**
          
          ProjectId - int (Primary Key) (Many-to-Many with Model, Workflow through ProjectModel and ProjectWorkflow joining tables, respectively)
          
          OwnerId - Guid
          
          Name - string
          
          StartDate - DateTimeOffset
          
          FinishDate - DateTimeOffset? (nullable)
          
**Table 4: Workflow**

          WorkflowId - int (Primary Key) (Many-to-Many with Project through ProjectWorkflow joining table)
          
          OwnerId - Guid
          
          Color - string
          
          PrimeId - int
          
          BaseCoatId - int
          
          ShadeId - int
          
          HighlightOneId - int
          
          HighlightTwoId - int
          
          Primer - virtual Paint
          
          BaseCoat - virtual Paint
          
          Shade - virtual Paint
          
          HighlightOne - virtual Paint
          
          SecondHighlight - virtual Paint
          
**Table 5: ProjectModel**

          ProjectModelId - int (Primary Key) (Joining table for Project and Model)
          
          OwnerId - Guid
          
          ProjectId - int
          
          Project - virtual Project
          
          ModelId - int
          
          Model - virtual Model
          
          Projects - virtual IEnumerable<Project>
          
          Models - virtual IEnumerable<Model>
          
**Table 6: ProjectWorkflow**

          ProjectWorkflowId - int (Primary Key) (Joining table between Project and Workflow)
          
          OwnerId - Guid
          
          ProjectId - int
          
          Project - virtual Project
          
          WorkflowId - int
          
          Workflow - virtual Workflow
          
          Projects - virtual IEnumerable<Project>
          
          Workflows - virtual IEnumerable<Workflows>
          
## Features
Version  1.0 / MVP | Version 2.0 / Stretch Goals
-------------------| -------------------------
Create, Read, Update and Delete Models | Create, Read, Update and Delete Notes for Projects
Create, Read, Update and Delete Paints | Create, Read, Update and Delete Notes for Workflows
Create, Read, Update and Delete Workflows | Add, Read, Update and Delete Paints for a Wishlist
Create, Read, Update and Delete Projects | Display joining table returns in Project Views
Add Models, Paints and Workflows to Projects |

## Planning
[Planning Document](https://docs.google.com/document/d/1cz9v9m6T4dUasN4nBdTGplcM4z0KZASWweCTwsDIySo/edit)
For this project, I tried to use Agile methodology by breaking the project up into daily sprints over the course of the project. I utilized a planning document, a database diagram, and a calendar (contained in the planning document) to make a rough sketch of what I needed to do each day for that day's sprint. As can be expected, certain parts went faster than anticipated, and others went slower.

## Stretch Goals
I would like to add notes functionality so that a user may make notes for individual Workflows to call out specific techniques, ideas, or whatever else they would like to record there. Similarly, I would like to add note functionality to the Projects for the same reasons. I'd also like to try to add the information returned from the joining tables directly into the Project Details view, instead of having to reference a separate area.

## Schedule
### Initial Schedule
