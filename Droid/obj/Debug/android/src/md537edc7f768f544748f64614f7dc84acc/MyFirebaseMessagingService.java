package md537edc7f768f544748f64614f7dc84acc;


public class MyFirebaseMessagingService
	extends com.google.firebase.messaging.FirebaseMessagingService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onMessageReceived:(Lcom/google/firebase/messaging/RemoteMessage;)V:GetOnMessageReceived_Lcom_google_firebase_messaging_RemoteMessage_Handler\n" +
			"";
		mono.android.Runtime.register ("AppFom.Droid.MyFirebaseMessagingService, AppFom.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MyFirebaseMessagingService.class, __md_methods);
	}


	public MyFirebaseMessagingService ()
	{
		super ();
		if (getClass () == MyFirebaseMessagingService.class)
			mono.android.TypeManager.Activate ("AppFom.Droid.MyFirebaseMessagingService, AppFom.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onMessageReceived (com.google.firebase.messaging.RemoteMessage p0)
	{
		n_onMessageReceived (p0);
	}

	private native void n_onMessageReceived (com.google.firebase.messaging.RemoteMessage p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}