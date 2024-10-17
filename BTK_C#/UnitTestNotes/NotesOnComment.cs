using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestNotes
{
    internal class NotesOnComment
    {
        // ********************  ASSERT methodunun overloadları : ******************** 

        // 1. Assert.AreEqual(beklenen,gerceklesen,delta) ==> Delta sonuçtaki tolere edilebilecek sapmaları belirler. Hesaplaması : |beklenen - gerceklesen| <= delta

        // 2. IgnoreCast : Bu sayede beklenen ve gerceklesen arasındaki büyük veya küçük harf problemlerini aşarız.

        // 3. Assert.AreNotEqual(beklenmeyen,gerceklesen) : Bu methodda istemediğimiz sonucu yazarız ve onun dışındakiler kabul edilir testi geçer

        // 4. Assert.AreSame : AreEqualdan farklı olarak sadece refrans tipi ile ilgilenir.

        // 5. Assert.Inconclusive("Açıklama"); : Bu yöntem test başarılı olsa da yeterli olmadığı durumlarda kullanılır. Açıklama girilerek gerekçesi açıklanır.

        // 6. Assert.InInstanceOfType(deger,typeof(type)) : Deger değişkeninin type türünde olup olmadığını kontrol eder. Assert.IsNotInstanceOfType ise tam tersi işlevdedir.

        // 7. Assert.IsTrue ve Assert.IsFalse bu methodlar ise doğru veya yanlış olup olmadığını kontrol eder.

        // 8. Assert.IsNull : Bu yöntemle girinlen değerin null olup olmadığı kontrol edilir. Assert.IsNotNull ise tam tersi olarak çalışır.

        // Assert.Fail : Test başarısız olduğunda çalışır.

        // ******************** COLLECTIONASSERT methodunun overloadları : ********************************* 

        // 1. CollectionAssert.AreEquivalent : Karşılaştırılan listelerin verilerinin aynı sayı ve değerde olması yeterlidir sırası önemsiz.

        // 2.  CollectionAssert.AreNotEquivalent : Bu methodda fazladan veri olmasının öbnemi yoktur fakat verilerin, karşılaştırılan veriler ile aynı sırada yazılması gerekir

        // 3.  CollectionAssert.AllItemsAreNotNull : Eklenen verilerin hiçbirinin null olmaması lazım

        // 4.  CollectionAssert.AllItemsAreUnique : Listenin tüm elemanlarının benzersiz olması istenir.

        // 5.  CollectionAssert.AllItemAreInstanceOfType : Burada ise verilen listedeki tüm elemanların aynı tipte olması gerekir.

        // 6.  CollectionAssert.IsSubsetOf(altKume,ustKume) : Verilen listelerin kume durumunu kontrol eder ve soldaki hali bize testi geçirir.  CollectionAssert.IsNotSubsetOf() ise tam tersidir.

        // 7.  CollectionAssert.Contains : Sorgulanan nesnenin listede olup olmadığını kontrol eder.  CollectionAssert.DoesNotContains ise bunun tam tersidir.

    }
}
