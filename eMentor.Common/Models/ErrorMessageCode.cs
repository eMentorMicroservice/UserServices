using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eMentor.Common.Models
{
    public static class ErrorMessageCode
    {
        public const string AUTH_FORBIDDEN_ERROR = "auth_forbidden_error";
        public const string EMAIL_INVALID = "email_invalid"; //Email invalid
        public const string USER_NOT_FOUND = "user_not_found"; //User not found
        public const string USER_IS_DEACTIVATE = "user_is_deactivate"; //User is deactivate
        public const string SERVER_ERROR = "server_error"; //Server Error
        public const string EMAIL_OR_PHONE_NUMBER_ALREADY_EXIST = "email_or_phone_number_already_exist"; //This email or phone number already exist.
        public const string EMAIL_OR_PHONE_NUMBER_INVALID = "email_or_phone_number_invalid"; //This email or phone number is invalid.
        public const string PASSWORD_INVALID = "password_invalid"; //This password is invalid.
        public const string UPDATE_PASSWORD_FAILED = "update_password_failed"; //password update is failed.
        public const string PASSWORD_INCORRECT = "password_incorrect"; //Your password is Incorrect.
        public const string FORGOT_PASSWORD_DONE = "forgot_password_done"; //Please check email or phone number
        public const string FIELDS_IS_EMPTY = "fields_is_empty"; //Field not empty
        public const string USERNAME_ALREADY_EXIST = "username_already_exist"; //This username already exist.
        public const string PROJECT_NAME_NOT_NULL = "project_name_not_null"; //This username already exist.
        public const string CAN_NOT_DELETE_USER = "can_not_delete_user"; //Can not delete User
        public const string CAN_NOT_DEACTIVATE_USER = "can_not_deactivate_user"; //Can not delete User
        public const string FIELD_NOT_EMPTY = "field_not_empty"; //field not empty
        public const string PASSWORD_HAS_CHANGED = "password_has_changed"; //Password has Changed
        public const string CHANGE_PASSWORD_EXPIRE = "change_password_expire"; //Change password expire
        public const string CHANGE_PASSWORD_DONE = "change_password_done"; //Change password Done
        public const string COURSE_NOT_FOUND = "course_not_found"; //This username already exist.
        public const string DELETE_DAYOFF_IS_FAILED = "delete_dayoff_is_failed"; //delete dayoff is failed.
        public const string DATETIME_INVALID = "datetime_invalid"; //This datetime is invalid.


        public const string CAN_NOT_UPGRADE_USER = "cannot_upgrade_user";
    }
}
