3.当使用上下文时重写方法OnModelCreating 直接不进行其他动作出现异常
One or more validation errors were detected during model generation:

DebugApp.XPectPatient: : EntityType 'XPectPatient' has no key defined. Define the key for this EntityType.
DebugApp.XPectReport: : EntityType 'XPectReport' has no key defined. Define the key for this EntityType.
DebugApp.XPectReportImage: : EntityType 'XPectReportImage' has no key defined. Define the key for this EntityType.
DebugApp.XPectImage: : EntityType 'XPectImage' has no key defined. Define the key for this EntityType.
DebugApp.XPectQueue: : EntityType 'XPectQueue' has no key defined. Define the key for this EntityType.
DebugApp.XPectSeries: : EntityType 'XPectSeries' has no key defined. Define the key for this EntityType.
DebugApp.XPectStudy: : EntityType 'XPectStudy' has no key defined. Define the key for this EntityType.
DebugApp.XPectStudyExtend: : EntityType 'XPectStudyExtend' has no key defined. Define the key for this EntityType.
DebugApp.XPectPhysician: : EntityType 'XPectPhysician' has no key defined. Define the key for this EntityType.
Entity: EntityType: EntitySet 'Entity' is based on type 'XPectPatient' that has no keys defined.
XPectReports: EntityType: EntitySet 'XPectReports' is based on type 'XPectReport' that has no keys defined.
XPectReportImages: EntityType: EntitySet 'XPectReportImages' is based on type 'XPectReportImage' that has no keys defined.
XPectImages: EntityType: EntitySet 'XPectImages' is based on type 'XPectImage' that has no keys defined.
XPectQueues: EntityType: EntitySet 'XPectQueues' is based on type 'XPectQueue' that has no keys defined.
XPectSeries: EntityType: EntitySet 'XPectSeries' is based on type 'XPectSeries' that has no keys defined.
XPectStudies: EntityType: EntitySet 'XPectStudies' is based on type 'XPectStudy' that has no keys defined.
XPectStudyExtends: EntityType: EntitySet 'XPectStudyExtends' is based on type 'XPectStudyExtend' that has no keys defined.
XPectPhysicians: EntityType: EntitySet 'XPectPhysicians' is based on type 'XPectPhysician' that has no keys defined.

2.The context cannot be used while the model is being created.
 This exception may be thrown if the context is used inside the OnModelCreating method or if the same context instance is accessed by multiple threads concurrently. 
 Note that instance members of DbContext and related classes are not guaranteed to be thread safe.

1.CreateDatabase is not supported by the provider.
