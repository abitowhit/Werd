# Werd
Aspx human vaidation bounce page which can be used with php forums like wordpress, phpbbs and drupal.
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

## Platform
php,.net,c#

## Software Options

* Drupal Captcha
* WordPress Captcha
* .net/aspx Captcha

## Software structure

The program is  written in c# using .net libraries. PHP interface to .net landing page.

## Installation

Requirements:

* .net 4.5 but will probalby work with other libs. Nothing really .net version specific.

    To come..
    

## License

GNU General Public License version 3.0 (GPLv3) (https://www.gnu.org/licenses/gpl-3.0.de.html)

## Limitations

Multiple solutions:

* Use where you want actual human input to access specific or general web access.
* In form
* Bounce page (forums, bbs)
* When used as full bounce page, it may deter crawlers from registering content on the site.  This is where specific URL path limiting can be beneficial.

## References:
 * [Werd(http://247coding.com/drupal/?q=node/9)
 

