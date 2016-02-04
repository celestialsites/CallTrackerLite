# CallTrackerLite
Call Tracker Module
This module was built to replace an Access Database application utilizing DNN 8 and its new SPA module features.

In addition, the module was developed using AngularJS.

#Installation Instructions
1. Install DNN 8 or later
2. Download and install the source code module installation Package.
3. Install the Angular Javascript library DNN package (angularjs_1.2.27.zip included in the Pre-Requisite folder)
4. Update the default skin bootstrap to version 3.3.6 (included in the Pre-Requisite folder, Thank you Scott Wilkinson)
5. Seed the Dispatcher Details data.
6. Seed the Dispatch Code Data.
7. Seed the Region Details data.

Check out my youtube video here:   https://youtu.be/RNyHPwiy2Zc


Button Definitions:
•	Open Calls - use this button to show all open or non-dispatched calls.
•	All Calls – Use this button to open a list of all of calls for editing or adding to calls.
•	Dispatcher Administration – Allow users with administration access to edit and modify the Dispatchers in the system.
•	Region Administration – Allow users with administration access to edit and modify the Regions and Cities in the system.
•	Dispatch Code Administration – Allow users with administration access to edit and modify the Dispatch Codes used in the system.
•	Cancel – Clear the Screen and start all over.
 

All Calls Button:
  
Use this screen to view all calls, enter new calls and to enter the initial dispatch information. When this screen loads you can either enter in the call information or Exit if the log is not needed.  

To use this page:
1.	Click on the Add Call button to log a new call.
2.	Click on the Edit button to edit an existing call.
3.	Click on the Dispatch button to add dispatcher information to a call.
4.	Click on the Delete button to delete a call.


 
New Call Logging:
You must fill out all fields.
  
•	Call type: This is where you will identify the type of call you are taking. 
•	Caller Name: The caller’s name
•	Address: The address at which the emergency is located
•	City: This is a drop down menu. Select the city where the call out is being made. 
•	Cross Streets (Optional): nearest major Cross Street or intersection.
o	NOTE: An attempt to collect this information should be made on every customer call.
•	Call Back Number: Needs to be a safe contact number for the customer. 
o	NOTE: If the customer is reporting a gas leak this cannot be a land line in the house.
•	Comments: Additional instructions for the call. i.e.: Smelling gas outside by the propane tank.
•	Save Button: This saves the call and stamps the Call time field. 

Dispatch Logging:
 
Once you click on the Dispatch Action, the above screen is shown.  It contains the Caller information and any Dispatch information if available.  To enter New Dispatch information, click on the Add Details button.  

You will be prompted for the following information:
 Please fill out all the fields:
•	Dispatch Code:  Please select the appropriate Dispatch Code from the list box 
•	Dispatcher:   Please select a Dispatcher
•	Comment: Any additional information you believe needs to be logged. 
•	Check if Dispatched:  Check the box if the call is being dispatched otherwise leave it open
•	Save Dispatch: Logs the dispatch into the table below.


