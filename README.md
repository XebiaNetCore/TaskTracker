# TaskTracker
A Task tracker  Application 


# Key  Design Approaches to  to be taken #

- Microservices architecture  using .net  core 
- Domain  Driven Design ( domain models  and events)
- Secured by identity using JWT
- Message based and Event based architecture using  Service bus 
- Ability to  Unit test   and  do integration  Testing  
- Implement API gateway pattern 
- CQRS pattern 
- InMemory / distributed  Caching
- Dockerization 



# User  Stories #
  * As  a User  I should be  able to  register into the  Task tracker system as an  Admin 
  * As an  Admin  User  I should be  able to  to login  to the task tracker system with an  EmailID and Password used during registration.
  * As an Admin  User  I should be  able to  Add   new User as  Team Member  to an existing   Project  in the system with an emailid  and default password  as “password”
  * As a Team Memberr  I should be  able to  login to the system  using the  EmailID and  default Password.
  * As a Team Member  I should be able to  change  my default Password.
  * As an  Admin  User  I should be  able to  create  a  new  Sprint definition
      - SprintID (String)
      - StartDateu 
      -	EndDate
  	  - CreatedDate
  	  - CreatedBy
  	  - LastModifiedDate
  	  - LastModifiedBy

* As an Admin User I should be able  to  create a New Project
    -	ProjectName
    -	ProjectDescription 
    -	CreatedDate
    - CreatedBy
    -	LastModifiedDate
    -	LastModifiedBy


* As an  Admin  User  I should be  able to create a  Feature  within a Project 
    -	FeatureName
    -	FeatureDescription
    -	ProjectID
    -	SprintID (String)
    -	Tags[]
    -	RankID
    -	FeatureOwnerID
    -	CreatedDate
    -	CreatedBy
    -	LastModifiedDate
    -	LastModifiedBy


* As an  Admin  User  I should be  able to associate one or many tags to the Feature to aid filtration and search.
	
* As an  Team Member   I should be  able to create a  Task  within a Feature
    -	TaskName
    -	TaskDescription
    -	TaskOwnerID
    -	SprintID
    -	FeatureID
    -	ProjectID
    -	CurrentStatus [notstarted, wip, completed, ]
    -	CreatedDate
    -	CreatedBy
    -	LastModifiedDate
    -	LastModifiedBy

* As an  Team Member   I should be  able to  list  Tasks 
* As an  Team Member   I should be  able to  mark  Task as  started 
* As an  Team Member   I should be  able to  mark  Task as  Completed   when  already started and not already completed 
* As a Team Member I should be able to transfer task to a different  Team member as its owner 


	
	


