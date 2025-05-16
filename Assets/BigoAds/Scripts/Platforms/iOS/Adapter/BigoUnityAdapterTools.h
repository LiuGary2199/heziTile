extern "C" {
    NSString* BigoIOS_transformNSStringForm(const char * string);
    void BigoIOS_dispatchSyncMainQueue(void (^block)(void));
    NSDictionary* BigoIOS_jsonObjectFromJsonString(NSString *jsonString);
    NSDictionary* BigoIOS_requestJsonObjectFromJsonString(const char * json);
} 
