namespace VRTK.Examples
{
    using UnityEngine;

    public class Turret : VRTK_InteractableObject
    {
        private GameObject bullet;
        private float bulletSpeed = 1000f;
        private float bulletLife = 5f;

        public override void StartUsing(GameObject usingObject)
        {
            base.StartUsing(usingObject);
            FireBullet();
        }

        protected void Start()
        {
            bullet = transform.Find("Bullet").gameObject;
            bullet.SetActive(false);
        }

        private void FireBullet()
        {
            GameObject bulletClone = BulletFactory.CreateBullet(); // Instantiate(bullet, bullet.transform.position, bullet.transform.rotation) as GameObject;
            bulletClone.transform.position = bullet.transform.position;
            bulletClone.transform.rotation = bullet.transform.rotation;
            bulletClone.SetActive(true);
            Rigidbody rb = bulletClone.GetComponent<Rigidbody>();
            rb.AddForce(-bullet.transform.forward * bulletSpeed);
            Destroy(bulletClone, bulletLife);
        }
    }
}