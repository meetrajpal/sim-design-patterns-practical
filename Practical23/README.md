## Task
* Factory design-pattern / Abstract factory design-pattern

Create one class library for BAL (Business access layer)
Create one API that will give overtime pay when passing employee (Id, hour)
This API will call the department factory which is created in BAL and it will return overtime pay on the basis of employee department name
You need to find employee department name from department Id
 
* For Factory design pattern:

There should be multiple department overtime calculations like
IT (hour * department pay (200 Rs)), Sales (hour * department pay (100 Rs)) and etc
Each subclass has its own department pay to get overtime.
 For Abstract Factory design pattern:

* There should be two department overtime calculations based on
IT and HR factories abstracted through Indoor factory
Sales and On-site factories abstracted through Outdoor factory
Each department should have its own calculation like
IT (hour * department pay (200 Rs)), Sales (hour * department pay (100 Rs)) and etc
Each factory has its own department pay to get overtime.

## Note
* Task is implemented in Department and Employee controllers.
* Repository Pattern has been implemented.
* Factories and Abstract Factories are implemented in Practical23.BAL\AbstractFactoriy, Practical23.BAL\Factories and Practical23.BAL\OvertimeCalcs
