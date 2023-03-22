# Mars-Rover<br><br>

It would be ideal to have docker desktop installed in the computer this repo will be cloned into as the database image (PostgreSQL) is containerized.<br>

Currently, a few endpoints needs to be properly connected to the frontend hence it is recommended to use the SwaggerUI for testing purpose. <br>
To test the endpoint, first run the project (it'll run both WebAPI and Web App (MVC), the API will run later so the Web App page needs to be refreshed once the API runs. <br>
You'll need to add a rover to start testing. Please use the create rover endpoint<br>
Next to add the user input (Currently it is working for one Rover's input at a time and not two rover at a time) but an endpoint is being worked on. This has been tested with both test inputs provided and returns the currect output. <br>
If you have a database viewer software (ie. DBeaver), you can connect to the databaase and see that it saves the inputs, the outputs, and calculates the coordinates in a list of int. The even values are X and the odd values are Y. 
The endpoints which are connects to frontend:<br>
- Rover History
- Rover list (This will depend on the data available in the database, so initially this may null);
