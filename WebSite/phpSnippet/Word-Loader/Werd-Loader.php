<?php
/**
* Plugin Name: Werd PHP Plugin
* Plugin URI: http://247Coding.com
* Description: Werd redirector. Replace Cookie value to match redirect page and set redirect URI if not /werd.
* Author URI: http://247Coding.com/werd
* Version: 1.0
* Copyright: (c) 2016 247Coding.com/WebMeToo.com
* License: GNU General Public License v3.0
* License URI: http://www.gnu.org/licenses/gpl-3.0.html
*/
$cookie_name = "WERD_VALIDATE";
$werd_redirect = "<script type=\"text/javascript\">window.location.replace(\"/werd\");</script>";
if(!isset($_COOKIE[$cookie_name])) {
echo $werd_redirect;
}
?>
