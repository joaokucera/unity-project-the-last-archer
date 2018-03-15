public class EnemyHealth : Health
{
	public override bool Hit()
	{
        bool result = base.Hit();

        if (!result) {
            gameObject.SetActive(false);
        }

        return result;
	}
}