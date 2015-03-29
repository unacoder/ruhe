#Changing the behavior of the Ruhe libraries

For release 2.0, only the ValidatorConfigurator is configurable. Future releases will further enable customizable behaviors.


# IValidatorConfigurator #

You are able to provide an alternate validator configurator to the Ruhe controls. The purpose of the configurator is to isolate all common setup code for validators for a site or application. The 2.0 release only enables the use of the configurator for the built-in IInputControl classes.

To configure a different class (other than the DefaultValidatorConfigurator), you will need to add the _ruhe_ section to your Web.Config. The class you specify must implement the IValidatorConfigurator interface. Extending the DefaultValidatorConfigurator is recommended at this point.
```
  <configSections>
    <section name="ruhe" type="Ruhe.Web.Configuration.RuheConfigurationSection, Ruhe.Web"/>
    ...
  </configSections>

  <ruhe>
    <validatorConfigurator type="Full.Name.Of.Class, Assembly.Name"/>
  </ruhe>
```