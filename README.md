demoSmartPhoneAPI-Tests
# Overview:
The demoSmartphoneAPI project is an API application for managing smartphone information. The application provides 
endpoints to add and retrieve smartphone details, such as the processor, RAM, and storage information.

# Test Coverage:
The test suite for demoSmartphoneAPI covers both unit tests and integration tests to ensure the functionality of 
the API endpoints and associated business logic. The tests validate the correct handling of requests, input validation, and response generation.

# Test Strategy:

> Unit Tests:
 CreateProcessorTestValid: Tests the successful creation of a processor by sending a valid request.
 CreateProcessorTestInvalid: Tests the validation of processor information by sending an invalid request.
 
 
> Integration Tests:
 RetrieveProcessorTest: Tests the retrieval of processor information by sending a request to the appropriate endpoint.
 UpdateProcessorTest: Tests the update of processor information by sending a request with modified details.
 DeleteProcessorTest: Tests the deletion of a processor by sending a request to remove a specific processor.

# Test Results:
CreateProcessorTestValid: Passed
The test successfully created a processor using valid information.

CreateProcessorTestInvalid: Passed
The test correctly identified and rejected an invalid processor request.

RetrieveProcessorTest: Passed
The test successfully retrieved processor information from the API.

UpdateProcessorTest: Passed
The test successfully updated processor information through the API.

DeleteProcessorTest: Passed
The test successfully deleted a processor through the API.

# Conclusion:
The demoSmartphoneAPI project has been thoroughly tested using a combination of unit tests and 
integration tests. The tests cover the essential functionality of the API endpoints, ensuring proper request handling, input validation, 
and response generation. All tests have passed, indicating that the API functions as expected and meets the specified requirements.
