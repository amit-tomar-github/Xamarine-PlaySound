using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using Android.Media;

namespace PlaySound
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        MediaPlayer mediaPlayerFirst;
        MediaPlayer mediaPlayerSecond;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Button btnAlarm = FindViewById<Button>(Resource.Id.btnAlarm);
            btnAlarm.Click += BtnAlarm_Click;

            Button btnNoti = FindViewById<Button>(Resource.Id.btnNoti);
            btnNoti.Click += BtnNoti_Click;

            //Set the maximum volume
            AudioManager am = (AudioManager)GetSystemService(AudioService);
            am.SetStreamVolume(Stream.Music, am.GetStreamMaxVolume(Stream.Music), 0);

           // mediaPlayerFirst = MediaPlayer.Create(this, Resource.Raw.Beep);
          
            mediaPlayerSecond = MediaPlayer.Create(this, Resource.Raw.Sound);

            Button btnMp3 = FindViewById<Button>(Resource.Id.btnMp3);
            btnMp3.Click += BtnMp3_Click;

            Button btnMp32 = FindViewById<Button>(Resource.Id.btnMp32);
            btnMp32.Click += BtnMp32_Click;
        }

        private void BtnMp32_Click(object sender, EventArgs e)
        {
            try
            {
                mediaPlayerSecond.Start();
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }
        }

        private void BtnMp3_Click(object sender, EventArgs e)
        {
            try
            {
                StopPlaying();
                mediaPlayerFirst = MediaPlayer.Create(this, Resource.Raw.Beep);
                mediaPlayerFirst.Start();
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }
        }

        private void StopPlaying()
        {
            try
            {
                if (mediaPlayerFirst != null)
                {
                    mediaPlayerFirst.Stop();
                    mediaPlayerFirst.Release();
                    mediaPlayerFirst = null;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        private void BtnNoti_Click(object sender, System.EventArgs e)
        {
            try
            {
                Android.Net.Uri notification = RingtoneManager.GetDefaultUri(RingtoneType.Notification);
                Ringtone r = RingtoneManager.GetRingtone(this, notification);
                r.Play();
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }
        }

        private void BtnAlarm_Click(object sender, System.EventArgs e)
        {
            try
            {
                Android.Net.Uri alarm = RingtoneManager.GetDefaultUri(RingtoneType.Alarm);
                Ringtone r = RingtoneManager.GetRingtone(this, alarm);
                r.Play();
            }
            catch (Exception ex) { Toast.MakeText(this, ex.Message, ToastLength.Long).Show(); }
        }
    }
}