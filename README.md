# MyCodingExamples

## Overview
| |Type|Name|Description|
|-|----|----|-----------|
|C#|Console|Adslot|Find index of longest sequence in integer array.|
|C#|Console|Aimedia|todo|
|C#,JavaScript|Web|AngularJS|todo|
|C#|Console|Aimedia|todo|
|C#|Console|AOPCastle|Aspect Oriented Programming using Castle Windsor.|
|C#|Console|AOPExample|todo|
|C#|Console|Brainteaser|Different implementation for puzzels from the Brainteaser website.|
|C#|Console|CodingdojoOrg|(seems to be duplicate of Brainteaser)|
|C#|Console|Deswik.MyTasks|This program is part of a task tracking system.|
|C#|Console|DigitalSimulator|Digital circuit simulator|
|F#|Console|FizzBuzz|Collection of multiple coding katas in F#.|
|C#|Console|GameOfLive|Implemenaton of the game of live.|
|C#|Console|FizzBuzz|FizzBuzz|
|C#|Console + Web|IAsset|Microservices/JSON|
|C#|Console|InheritanceSample|N/A|
|C#|Console + WPF|Minesight|Loosely couple using in memory bus to communicate, replace events with messages.|
|C#|Console|MYOB|MYOB - Technical Test|
|C#|Console|ParkIQ|Car park manager applicayion.|
|C#|Console|ParkIQ|Car park manager applicayion.|
|C#|Console + Web|QUT|Microservices using Nancy and Enterprise Framework.|
|C#|Console|WiseTechGlobal|ChequeWriter, RomanCalculator, RomanNumerals|
|C++|Console|KataRomanCalculator|Calculator. Using GoogleMocks/Tests and SOLID, DRY, LEAN|
|C++|Console|KataRomanNumerals|Roman numerals. Using GoogleMocks/Tests and SOLID, DRY, LEAN|
|C++|Console|KataTennis|Keeping track of a tennis match (project became bigger than expected). Using GoogleMocks/Tests and SOLID, DRY, LEAN|
||||**Other Repositories below**|
|C#|Console + Web|[Doctors Appointment](https://github.com/tschroedter/DoctorsAppointment)|Microservices + Enterprise Framework|
|C#|Console + WPF|[Selkie](https://github.com/tschroedter/Selkie)|RabbitMQ, Services, WPF, losely coupled, traveling sales man...|

# Adslot
## C#, Console Application
### Description
Find index of longest sequence in integer array.

Examples: 

{0, 1, 2} returns 0
{4, 0, 1, 2} returns index 1
### Main NuGet packages:
- JetBrains.Annotations
- NUnit.Framework

# Agtrix 
## C#, WPF Application
### Description
Very basic sugar farm/mill management application using WPF, Castle Windsor and Caliburn Micro. Implemented using MVVM, Repositories, Services and everything covered by tests. (see Design.docx)

*The solution is using my AutoNSubstituteData attribute class to auto mock dependencies in tests. The class is based on the Autofixture package.*

### Main NuGet packages:
- Caliburn.Micro
- Castle.Windsor
- JetBrains.Annotations
- Ploeh.AutoFixture
- Ploeh.AutoFixture.AutoNSubstitute
- Ploeh.AutoFixture.NUnit3
- NUnit.Framework
- NSubstitute


# Aimedia
## todo
### Description
todo
### Main NuGet packages:
todo

# AngularJS
## todo
### Description
todo
### Main NuGet packages:
todo

# AOPCastle
## C#, Console Application
### Description
Aspect Oriented Programming using Castle Windsor. This project is implementing a LogAspect using interface IInterceptor. More aspects can be found in the Selkie.AOP project.
### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations
- Newtonsoft.Json


# AOPExample
## todo
### Description
todo
### Main NuGet packages:
todo

# AsyncTestConsole
## C#, Console Application
### Description
Simple async/wait example
### Main NuGet packages:
N/A

# Brainteaser
## C#, Console Application
### Description
Different implementation for puzzels from the Brainteaser website.
- FrogRiverOne
- InterviewZen
- MaxCounters
- MaxCounters
- PassingCars
- PermCheck
- PermMissingElem
- PermMissingElem
- TestCodibility

### Main NuGet packages:
N/A

# Codility
## todo
### Description
(seems to be duplicate of Brainteaser)
### Main NuGet packages:
N/A

# CodingdojoOrg
## C#, Console Application
### Description
Implementation of the Minesweeper game. Code is covered by unit and integration tests.
### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations
- NUnit.Framework
- NLog

# Deswik.MyTasks
## C#, Console Application
### Description
**Deswik.MyTasks Test**
This program is part of a task tracking system.

The company wants to enter an employee's Id to see when 
they will be able to finish all their assigned tasks.
Each subsidary has different work hours (eg. 8 hours per day, 7.5 hours per day, etc). 
Also, each employee could work a different FTE (full time equivalent). 


**Example**
An employee with an FTE of 0.5 working for a company with an 
8 hour work day would only work 4 hours each day. To simplify the test, 
we assume employees work every day. If this employee has a 12 hour task, 
it will take 3 days to complete it.


**Your job** 
The program has already been written by a junior programmer, but apparently the
customer said its 'full of bugs' and refused to accept it.

Add some automated tests for this process. We want to make sure the logic to calculate
the finish date is correct. Fix any bugs you find along the way.

Also keep in mind that the automated tests cannot use any exteral services (eg. a database)
because we must run it on our build server. So make sure your tests just test the calculation logic
without connecting to a database. You will need to refactor the code to acheive this.

Sub-Projects
- Deswik.MyTasks.DAL
- Deswik.MyTasks.Domain
- Deswik.MyTasks.Entities
- Deswik.MyTasks.Entities
### Main NuGet packages:
- Castle.Windsor
- NSubstitute
- NUnit.Framework

# DigitalSimulator
## C#, Console Application
### Description
Digital circuit simulator
### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations- 
- NUnit.Framework
- NLog
- NSubstitute
- Specflow

# FizzBuzz
## F#, Console Application
### Description
Collection of multiple coding katas in F#:
- FizzBuzz
- BankingOCR
- RomanNumbers

### Main NuGet packages:
NUnit.Framework
FsUnit


# GameOfLive
## C#, Console Application
### Description
Implemenaton of the game of live.

*The solution is using my AutoNSubstituteData attribute class to auto mock dependencies in tests. The class is based on the Autofixture package.*

### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations
- Ploeh.AutoFixture
- Ploeh.AutoFixture.AutoNSubstitute
- Ploeh.AutoFixture.NUnit3
- NUnit.Framework

# IAsset
## C#, Console Application
### Description
Microservices

Task
Design and develop an MVC/Web API dashboard that will manage daily flights inside an airport
terminal gate.
User Stories 
1) As a gate manager, I would like to view and query all my daily flights within the specific gate.
2) As a gate manager, I would like to add new flight to a specific gate. (see assumption #2)
3) As a gate manager, I would like to update arrival and/or departure time for specific flight.
(see assumption #2 and #3)
4) As a gate manager, I would like to cancel a flight.
5) As a gate manager, I would like to assign a flight to another gate.

Assumptions 
1) Default departure time is “ArrivalTime+29 mins” unless modified by user.
2) Do not store data in a database. You will have repository at Data Access Layer to initialize
the objects. For the sample data, consider at least 2 gates and 10 flights on each.
3) By default overlap time is 30 minutes between each flight. If flight A arrives at 10.00AM the
next flight should arrive to gate at or after 10.30AM. We assume disembarking flight will
take less than 30 mins unless modified by the user.
4) If you cannot update the flight because of overlap issue, you either need to push the rest of
the flights or assign it to another available gate.
5) The terminal only shows today schedules from 12:00AM to 11:59PM.

### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations
- Ploeh.AutoFixture
- Ploeh.AutoFixture.AutoNSubstitute
- Ploeh.AutoFixture.NUnit3
- NUnit.Framework
- Newtonsoft.Json
- Nancy
- Selkie.Windsor

# InheritanceSample
## C#, Console Application
### Description
N/A
### Main NuGet packages:
N/A

# Minesight
## C# Console and WPF Application
### Description
(loosely couple using in memory bus to communicate, replace events with messages)

*Story-1:* to query for the closest point id in my point set compared to a query
point
As a User, I want to query for the closest point id in my point set compared to a query point, so that I find locations
for building my drill plan.
It is important for me to be able to enter a co-ordinate and compare it against all my known points in the database,
and locate the closest point in that database.

*Acceptance Criteria*
1. I expect to be able to specify a source for my points (see Appendix I: Source File Format).
2. I expect to be able to specify a query point.
3. I expect to be able to use positive or negative values of the query point.
o i.e. X=1000,Y=10,Z=12 or X=-12, Y=2000, Z=-1201
4. I expect that the point ID returned will be the closest point to the query point.
5. I expect that this is documented.

*Story-2:* be able to shift and translate all my points by a vector
As a User, I want to be able to translate all my points by a vector, so that I can apply a primitive adjustment to my
coordinate system to match my query point’s coordinate system.
The point I am querying might be in a different coordinate system than the point data itself, I need a way to shift
that data.

*Acceptance Criteria*
1. I expect to be able to enter an X, Y, and Z coordinate, and have my entire source data shift by that.
2. I expect that this is documented.

*Story-3:* be able to specify a number of points to return closest to the query point
As a User, I want to be able to specify a number of points as closest point, so that I can select the best point to work
from.

*Acceptance Criteria*
1. I expect to be able to specify the number of points to report as closest.

*Story-4:* be to interact with the program using a Graphical User Interface
As a User, I want to be able to interact with the program using a Graphical User Interface, so that I don’t need to
understand how a command line works

*Acceptance Criteria*
1. I expect all functionality to be accessible through the interface
2. I expect to see the results of the program on the interface


### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations
- NUnit.Framework
- NSubstitute
- Selkie.Windsor
- Selkie.EasyNetQ
- CsvReader


# MYOB
## C#, Console Application
### Description
MYOB - Technical Test

### Main NuGet packages:
JetBrains.Annotations
XUnit
Fody

# ParkIQ
## C#, Console Application
### Description
Create a set of working classes representing a car park as described below. The code you write should contain sufficient commenting and be of production quality. You may use the internet during your time. You may also ask questions to clarify the details described below.
- A car park has a name
- A car park has a certain number of bays (car spots). (BaysManager)
- A car park has a list of vehicles currently in the car park (VehiclesManager)
- A car park has a property indicating how full the car park (Need more info % or count)
- Vehicles can enter and exit the car park. When a vehicle enters the car park, the occupancy count goes up by 1. When a vehicle exits the car park, the occupancy count goes down by 1. 1) A vehicle cannot enter the car park if it is full. 2) A vehicle cannot exit the car park if its fee has not been paid.
- All vehicles have a weight
- All vehicles have a fee for parking in the car park. This vehicle fee is $2
- Vehicles have the following details.
-- Standard Car: Fee is calculated as vehicle fee + $5
-- Luxury Car: Fee is calculated as standard car fee + $3
-- Motorbike: Fee is calculated as vehicle fee + $2.
-- Truck: Fee is calculated as vehicle fee + $10.
-- Vehicle Extra charges.
-- An extra charge of $3 is added to a vehicle fee if its weight is over 100kg.
- When calculating the fee keep in mind that new fees could be added to the system. Developers should only need to extend the code not modify existing code to do this

Demonstrate the following order of events in a console or windows forms application using the classes you have built:
1. Initialise the car park with 10 bays and a name of “Test carpark”
2. Have one of each type of vehicles enter the car park. The truck should have a weight of 101 kg.
3. List the details of all the vehicles in the car park including their type and outstanding fees.
4. Pay the outstanding fee for the luxury car
5. List the details of all the vehicles in the car park including their type and outstanding fees.
6.  Have the luxury car exit the car park
7.  List the details of all the vehicles in the car park including their type and outstanding fees.
8. Pay the outstanding fees for the remaining cars
9. Have the remaining cars exit the car park
10. List the details of all the vehicles in the car park including their type and outstanding fees.
11. Have a motorbike enter the car park
12. Have the motorbike exit the car park
13.  List the details of all the vehicles in the car park including their type and outstanding fees.

### Main NuGet packages:
- Castle.Windsor
- JetBrains.Annotations
- NUnit.Framework
- NSubstitute
- Selkie.Windsor

# QUT
## C#, Console Application
### Description
Microservices using Nancy and Enterprise Framework.

*The solution is using my AutoNSubstituteData attribute class to auto mock dependencies in tests. The class is based on the Autofixture package.*

### Main NuGet packages:
- Castle.Windsor
- Castle.Windsor
- JetBrains.Annotations
- Ploeh.AutoFixture
- Ploeh.AutoFixture.AutoNSubstitute
- Ploeh.AutoFixture.NUnit3
- NUnit.Framework
- Newtonsoft.Json
- Nancy
- Selkie.Windsor
- EntityFramework


# WiseTechGlobal
## C#, Console Application
### Description
- ChequeWriter
- RomanCalculator
- RomanNumerals

### Main NuGet packages:
JetBrains.Annotations
NUnit.Framework
