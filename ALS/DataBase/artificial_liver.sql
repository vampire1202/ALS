/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306_1
Source Server Version : 50622
Source Host           : localhost:3306
Source Database       : artificial_liver

Target Server Type    : MYSQL
Target Server Version : 50622
File Encoding         : 65001

Date: 2016-12-18 13:26:54
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for guardian_data
-- ----------------------------
DROP TABLE IF EXISTS `guardian_data`;
CREATE TABLE `guardian_data` (
  `surgery_no` varchar(255) NOT NULL,
  `time_stamp` varchar(255) DEFAULT NULL,
  `heart_rate` varchar(255) DEFAULT NULL,
  `systolic_pressure` varchar(255) DEFAULT NULL,
  `diastolic_pressure` varchar(255) DEFAULT NULL,
  `blood_oxygen` varchar(255) DEFAULT NULL,
  `ecg_features` blob,
  PRIMARY KEY (`surgery_no`)
) ENGINE=InnoDB DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of guardian_data
-- ----------------------------

-- ----------------------------
-- Table structure for pressure_data
-- ----------------------------
DROP TABLE IF EXISTS `pressure_data`;
CREATE TABLE `pressure_data` (
  `surgery_no` varchar(255) DEFAULT NULL COMMENT '手术号',
  `time_stamp` varchar(255) DEFAULT NULL COMMENT '时间',
  `in_blood_pressure` varchar(255) DEFAULT NULL COMMENT '采血压',
  `plasma_inlet_pressure` varchar(255) DEFAULT NULL COMMENT '血浆入口压P1st',
  `arterial_pressure` varchar(255) DEFAULT NULL COMMENT '动脉压',
  `venous_pressure` varchar(255) DEFAULT NULL COMMENT '静脉压',
  `plasma_pressure` varchar(255) DEFAULT NULL COMMENT '血浆压',
  `transmembrane_pressure` varchar(255) DEFAULT NULL COMMENT '跨膜压'
) ENGINE=InnoDB DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of pressure_data
-- ----------------------------

-- ----------------------------
-- Table structure for pump_speed_data
-- ----------------------------
DROP TABLE IF EXISTS `pump_speed_data`;
CREATE TABLE `pump_speed_data` (
  `surgery_no` varchar(255) DEFAULT NULL,
  `time_stamp` varchar(255) DEFAULT NULL,
  `cumulative_time` varchar(255) DEFAULT NULL,
  `blood_pump` varchar(255) DEFAULT NULL,
  `separation_pump` varchar(255) DEFAULT NULL,
  `dialysis_pump` varchar(255) DEFAULT NULL,
  `tripe_pump` varchar(255) DEFAULT NULL,
  `filtration_pump` varchar(255) DEFAULT NULL,
  `circulating_pump` varchar(255) DEFAULT NULL,
  `heparin_pump` varchar(255) DEFAULT NULL,
  `warmer` varchar(255) DEFAULT NULL,
  `blood_pump_t` varchar(255) DEFAULT NULL COMMENT '血液泵累计',
  `separation_pump_t` varchar(255) DEFAULT NULL COMMENT 'FP累计',
  `dialysis_pump_t` varchar(255) DEFAULT NULL COMMENT 'DP累计',
  `tripe_pump_t` varchar(255) DEFAULT NULL COMMENT 'RP累计',
  `filtration_pump_t` varchar(255) DEFAULT NULL COMMENT 'FP2累计',
  `circulating_pump_t` varchar(255) DEFAULT NULL COMMENT 'CP累计',
  `heparin_pump_t` varchar(255) DEFAULT NULL COMMENT 'SP累计'
) ENGINE=InnoDB DEFAULT CHARSET=gbk;

-- ----------------------------
-- Records of pump_speed_data
-- ----------------------------
