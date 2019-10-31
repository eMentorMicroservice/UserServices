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
        public const string LIST_HOLIDAY_IS_EMPTY = "list_holiday_is_empty"; //list holiday is empty.
        public const string INSERT_HOLIDAYS_IS_FAILED = "insert_holidays_is_failed"; //insert holidays is failed.
        public const string INSERT_RATEOVERTIME_IS_FAILED = "insert_rateovertime_is_failed"; //insert rate overtime is failed.
        public const string DAYOFF_IS_NOT_AVAILABLE = "dayoff_is_not_available"; //This dayoff is not available.
        public const string UPDATE_DAYOFF_FAILED = "update_dayoff_failed"; //dayoff update is failed.
        public const string PROJECT_NAME_NOT_NULL = "project_name_not_null"; //This username already exist.
        public const string CAN_NOT_DELETE_USER = "can_not_delete_user"; //Can not delete User
        public const string CAN_NOT_DEACTIVATE_USER = "can_not_deactivate_user"; //Can not delete User
        public const string FIELD_NOT_EMPTY = "field_not_empty"; //field not empty
        public const string PASSWORD_HAS_CHANGED = "password_has_changed"; //Password has Changed
        public const string CHANGE_PASSWORD_EXPIRE = "change_password_expire"; //Change password expire
        public const string CHANGE_PASSWORD_DONE = "change_password_done"; //Change password Done
        public const string NUM_DAYOFF_NOT_IS_VALID = "num_dayoff_not_is_valid"; // time b4 off atleast n day
        public const string LIST_DAYOFF_IS_EMPTY = "list_dayoff_is_empty"; //list dayoff is empty. 
        public const string START_TIME_INVALID = "start_time_invalid"; //start time invalid
        public const string FINISH_TIME_INVALID = "finish_time_invalid"; //finish time invalid
        public const string YOU_CANT_LOG_OT_FOR_YESTERDAY = "you_cant_log_ot_for_yesterday"; //you cannot log over time for yesterday
        public const string WORK_TIME_INVALID = "work_time_invalid"; //work time invalid
        public const string COURSE_NOT_FOUND = "course_not_found"; //This username already exist.
        public const string DELETE_DAYOFF_IS_FAILED = "delete_dayoff_is_failed"; //delete dayoff is failed.
        public const string DATETIME_INVALID = "datetime_invalid"; //This datetime is invalid.
        public const string USER_IS_EARLY_ACTIVATE = "user_is_early_activate"; // User is early activate
        public const string USER_IS_ACTIVATED = "user_is_activated"; // User is activated
        public const string USER_HAS_BEEN_LOCKED = "user_has_been_locked"; // User has been locked
        public const string OVERTIME_NOT_FOUND = "overtime_not_found"; // Overtime not found
        public const string CANT_REMOVE_OT = "cant_remove_ot"; // can't remove ot
        public const string RATE_OVERTIME_NOT_FOUND = "rate_overtime_not_found"; //Rate overtime not found
    }
}
