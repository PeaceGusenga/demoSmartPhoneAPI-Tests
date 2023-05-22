Feature: Test /GetAllBrands enpoint

Background:
    * url 'https://localhost:5002'

Scenario: Verify Status Code
    Given path '/GetAllBrands'
    When method get
    Then status 200

Scenario: Verify Response Body has Expected Structure
    Given path '/GetAllBrands'
    When method get
    Then status 200
    And match response == 
    """
    [
        {
            "BrandID": "#number",
            "BrandName": "#string",
            "BrandNetWorth": "#number"
        }
    ]
    """

Scenario: Verify Response Body - Empty Result
    Given path '/GetAllBrands'
    When method get
    Then status 200
    And match response == []
