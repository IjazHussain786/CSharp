using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam20._12._2015.AttackTypes
{
    public class Blobplode : AttackType
    {
        private const int BlobplodeHealthEffect = 2; //To divide.
        private const int BlobplodeDamageEffect = 2; //To multiply.
        public Blobplode()
            : base(BlobplodeHealthEffect, BlobplodeDamageEffect)
        {
        }
    }
}
