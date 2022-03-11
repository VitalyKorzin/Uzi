using System.Collections;
using UnityEngine;

public class Uzi : Weapon
{
    private readonly float _delay = 0.03f;
    private readonly int _bulletsCountInQueue = 3;
    private int _bulletsFiredCount;

    public override void Shoot(Transform shootPoint)
    {
        StartCoroutine(ShootBurst(shootPoint));
    }

    private IEnumerator ShootBurst(Transform shootPoint)
    {
        _bulletsFiredCount = 0;
        var delay = new WaitForSeconds(_delay);

        while (_bulletsFiredCount < _bulletsCountInQueue)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            _bulletsFiredCount++;
            yield return delay;
        }
    }
}