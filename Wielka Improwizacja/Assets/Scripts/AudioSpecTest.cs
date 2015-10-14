using UnityEngine;
using System.Collections;

public delegate void OnMoveBeingGenerated (MOVE m );

public class AudioSpecTest : MonoBehaviour {
	public OnMoveBeingGenerated onMoveBeingGenerated;

	float[] freqData = new float[8192];
	public AudioListener listener;
	
	float[] band;
	
	void Start()
	{
		if ( sampleInterval <= 0 ) throw new UnityException("sample interval must be greater than zero");

		int n = freqData.Length;
		int k = 0;
		for(var j=0;j<freqData.Length;j++)
		{
			n /= 2;
			if(n==0) break;
			k++;
		}
		band  = new float[k+1];
		for (int i=0;i<band.Length;i++)
		{
			band[i] = 0;
		}

		//InvokeRepeating("check", 0, 1f/15f); // update at 15 fps
	}

	IEnumerator _check;
	public int samplePointsNumber;
	public float sampleInterval;

	public void StartGen () {
		if ( _check == null ) StartCoroutine(_check= Check ());
	}

	public void StopGen () {
		if ( _check != null ) StopCoroutine(_check);
	}
	IEnumerator Check()
	{
		while ( true){ 
			yield return new WaitForSeconds(sampleInterval);
			AudioListener.GetOutputData (freqData,0);//.GetSpectrumData(freqData, 0, FFTWindow.Rectangular);
			
			int k = 0;
			int crossover = 2; 
			for(int i=0;i< freqData.Length;i++)
			{  
				var d = freqData[i];
				var b = band[k];       
				band[k] = (d > b)? d:b;   // find the max as the peak value in that frequency band.
				if ( i>crossover-3)
				{
					k++;
					crossover *= 2;   // frequency crossover point for each band.
				}  
			}

			float sum = 0;
			int offset = Mathf.FloorToInt(band.Length/samplePointsNumber);
			if ( offset == 0 ) throw new UnityException ("too many sample points");
			for (int i = 0 ; i < band.Length; i += offset ) {
				sum += band[i];
				band[i] = 0;
			}
			sum /= (float)samplePointsNumber;

			onMoveBeingGenerated( ConvertToMove(sum));
		}
	}

	MOVE ConvertToMove ( float v ) {
		if ( v > 0.75f & v <= 1 ) return MOVE.UP;
		else if ( v <= 0.75f & v > 0.5f ) return MOVE.LEFT;
		else if ( v <= 0.5f & v > 0.25f ) return MOVE.RIGHT;
		else if ( v <= 0.25f & v >= 0 ) return MOVE.DOWN;
		else return (MOVE) Random.Range(0,4);
	}
}
