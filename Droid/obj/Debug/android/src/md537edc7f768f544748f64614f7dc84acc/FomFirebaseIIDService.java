package md537edc7f768f544748f64614f7dc84acc;


public class FomFirebaseIIDService
	extends com.google.firebase.iid.FirebaseInstanceIdService
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTokenRefresh:()V:GetOnTokenRefreshHandler\n" +
			"";
		mono.android.Runtime.register ("AppFom.Droid.FomFirebaseIIDService, AppFom.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FomFirebaseIIDService.class, __md_methods);
	}


	public FomFirebaseIIDService ()
	{
		super ();
		if (getClass () == FomFirebaseIIDService.class)
			mono.android.TypeManager.Activate ("AppFom.Droid.FomFirebaseIIDService, AppFom.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onTokenRefresh ()
	{
		n_onTokenRefresh ();
	}

	private native void n_onTokenRefresh ();

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
