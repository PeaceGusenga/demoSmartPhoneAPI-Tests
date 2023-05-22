package smartphone.api;

import static org.junit.Assert.assertTrue;
import com.intuit.karate;

import org.junit.Test;
/**
 * All Unit Tests built for SmartPhoneAPI.
 */
public class AppTest 
{
    @Karate.Test1
    Karate testGetAllProcessorsAPI()
    {
        return Karate.run("getAllProcessors.feature").relativeTo(getClass());
    }

    @Karate.Test2
    Karate testGetAllBrandsAPI()
    {
        return Karate.run("getAllBrands.feature").relativeTo(getClass());
    }

    @Karate.Test3
    Karate testGetAllSmartPhonesAPI()
    {
        return Karate.run("getAllSmartPhones.feature").relativeTo(getClass());
    }

    @Karate.Test4
    Karate testAddProcessorsAPI()
    {
        return Karate.run("addProcessor.feature").relativeTo(getClass());
    }
}
