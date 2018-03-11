# Werd
Aspx human validation bounce page which can be used with php forums like wordpress, phpbbs and drupal or inline forms.

It can be used as either a session/cookie based bounce page or within a form to control access to the final submission button or panel.

# Bounce Example 1
![Bounce Example 1](https://github.com/abitowhit/Werd/blob/master/werdshot.png)

# Bounce Example 2
![Bounce Example 2](https://github.com/abitowhit/Werd/blob/master/werdshot2.png)

# Inline Form Example
![Form Example](https://github.com/abitowhit/Werd/blob/master/werdshotform.png)

## Overview
Werd is a captcha type solution which uses pseudo generated sentences with only one actual solution.

Solution is pulled randomly across multiple text files, randomly generated into pseudo sentences of random sizes.
Random pseudo sentences are generated in line with the acutal valid pseudo sentence, also containing random sizes.
This makes it easier to spot the valid words if you are a human, but not so easy for bots.
Everything randomly changes on each iteration.
Also works for mobile platforms automatically by generating a dropdown list instead of a select list.

Can be used to control a specific form within a site or generally as a bounce page, allowing it to be used as a php front end to forums.

Though I have not yet set it up this way, it can be launched specifically for page URL paths such as logins, admin, etc.

For bounce pages, a cookie is set.  In the php method, if cookie does not exist it forwards to the werd aspx landing page.
The Werd aspx page sets the cookie and forwards back to the landing page configured in the web.config file.
If cookie is already set, php continues on the the php page.

For form pages, button or panel is hidden from view if session/cookie is not set.  Within form, Werd sets the cookie/session and then displays the panel or button.  Ajax makes the form senerio fairly seemless.

## Platform
* c#
* php

## Software Options

* Drupal Captcha
* WordPress Captcha
* .net/aspx Captcha

## Software structure

The program is  written in c# using .net libraries. PHP interface to .net landing page.

## Installation

Requirements:

* .net 4.5 but will probalby work with other libs. Nothing really .net version specific.
* Installation of werd directory and files on IIS server and set as an application so that it processes the aspx page.


    To come..
    

## License

GNU General Public License version 3.0 (GPLv3) (https://www.gnu.org/licenses/gpl-3.0.de.html)

## Limitations
* When used as full bounce page, it may deter crawlers from registering content on the site.  This is where specific URL path limiting can be beneficial.
* Requires IIS server with .net.
* Will not run on apache and other web hosts, but can be leveraged by them.

## Multiple solutions:

* Use where you want actual human input to access specific or general web access.
* In form
* Bounce page (forums, bbs)

## References:
 * [Werd](http://247coding.com/drupal/?q=node/9) Werd Docs on 247Coding.com
 

