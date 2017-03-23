/*
MySQL Data Transfer
Source Host: localhost
Source Database: heilscare
Target Host: localhost
Target Database: heilscare
Date: 2016/10/31 16:15:41
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for usertable
-- ----------------------------
CREATE TABLE `usertable` (
  `Name` char(10) DEFAULT NULL,
  `Id` int(10) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `usertable` VALUES ('LiuPeng', '1');
INSERT INTO `usertable` VALUES ('YangJian', '2');
