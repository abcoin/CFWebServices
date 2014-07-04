CFWebServices
=============
This is the C# implementation of Amazon SES email sender.

How to define required values:

INSERT INTO `abe`.`EmailOutgoing` (`requestId`, `priorityId`, `statusId`, `fromAddress`, `toAdresses`, `mailSubject`, `body`, `requestDateTime`, `sendDateTime`, `comment`)
VALUES (NULL, NULL, '0', 'support@icoinhost.com', 'destination@example.com', 'title', 'body', NULL, NULL, NULL);


1). the value '0' of statusId means ReadyToSend,, set it if you want to send email out.

2). after the mail service sends out email, the value of statusId will be updated to '1', indicates it is already sent. 
