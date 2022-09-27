[![Nuget](https://img.shields.io/badge/nuget-v12.0.4-blue.svg)](https://github.com/silvertech/KenticoURLRedirection-Xperience13)
# Kentico 13 URL Redirection Module (WORK IN PROGRESS)
This module adds an interface in the CMS to allow a user to edit and manage URL Redirects in one place. The module supports multi-site instances. The latest version of this module is Version 13.0.4. The source code for this module is included in this repo if you wish to clone and modify it anyway you see fit. 

## Compatibility
 ** - Compatible with .NET Core MVC sites ONLY**
 - This module has been developed with .NET Core in mind; It is not supported on MVC 5 versions of Xperience 13
 - Xperience version 13.0.73 or greater 	

## Installation Instructions

Install the latest version of the Kentico URL Redirection [nuget package](https://www.nuget.org/packages/KenticoURLRedirection/)
`Install-Package KenticoUrlRedirection`

Install this nuget package **ONLY** to the CMSApp project of your MVC solution. Then, add a reference to the DLL to your MVC project. Do not install this nuget package into both the CMSApp and MVC projects.

After installation, check the event log of the site and you should see a line like this:
![Module Installed Successfully](https://github.com/silvertech/KenticoURLRedirectionModule/blob/master/Readme%20Assets/moduleintalled-eventlog.png?raw=true)

To update the module to a more recent version, simply update the NuGet package.

### Adding Module to .NET Core MVC Site
Once the module is installed into the solution, you can then begin working on adding references and 

## Module Overview
The Kentico URL Redirection module contains one class, **Redirection**, that is not customizable. The class' fields are as follows:

| Field Name  | Data Type | Form Control | Descrpiton |
|--|--|--|--|
| RedirectionTableID | Integer | N/A (Not Editable) | Unique ID of the redirection item |
| RedirectionOriginalUrl | Text (2000) | Text Box | URL Alias that will be redirected. Ex: **/original-url** |
| RedirectionTargetUrl | Text (2000) | URL Selector | Internal alias or External URL that the Original URL field will be redirected to. Ex: **/target-url** Ex: **https://www.external-domain.com** |
| RedirectionComment | Long Text | Text Area | A field that allows a content editor to describe a redirect or enter the purpose of a redirect |
| RedirectionSiteID | Integer | Site Selector | Drop down list that allows a user to specify which site the redirect is for. Default is the current site the user is on. |
| RedirectionType | Text (3) | Drop Down List | Allows the user to specify if the redirect is a 301 or 302 redirect. |

The module can be accessed by going to **Applications>Custom>Kentico URL Redirection**.

## License
This project uses a standard MIT license which can be found [here](https://github.com/silvertech/KenticoURLRedirectionModule/blob/master/LICENSE).

## Contribution
Contributions to this module are welcome. All the source files for this module are included and you just need to add the project to a Kentico Web Application solution and you can start editing anything you like. A ZIP export of the most recent, _unsealed_, version of the module is also included in the root of this repo so you can easily import the module database items into your Kentico project through the **Sites** application. This file is named **KenticoURLRedirection_12.0.4.zip** and will be needed if you want to edit anything related to the module inside the CMS.

 Submit a pull request to the repo with your code changes as well as an updated ZIP file (if CMS changes were made) and we will review and provide feedback. We will also update the NuGet package to a new version once we approve your changes.
