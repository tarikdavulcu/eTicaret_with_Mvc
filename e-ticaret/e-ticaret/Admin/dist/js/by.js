
function adminLogin() {
    var prm = "{'ka':'" + document.getElementById("ka").value + "','ks':'" + document.getElementById("ks").value + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/AdminGiris",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",

          success: function (result) {
              var data = result.d;

              if (data != "0") {
                  location.href = "index.html";

              }
              else {
                  document.getElementById("ka").value = "";
                  document.getElementById("ks").value = "";
              }

          },
          error: function (err) {
          }
      });
}

function kontrol() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/LoginKontrol",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",

          success: function (result) {
              if (result.d == true) {
                  location.href = "index.html";

              }
              else {
              }

          },
          error: function (err) {
          }
      });

}

function kullaniciBilgi() {
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/KullaniciBilgi",
        data: {},
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (result) {
            var myData = JSON.parse(result.d);
            var data = myData.Table;
            if (data == "Login") {
                location.href = "index.html";
            }
            else {
                for (var i = 0; i < data.length; i++) {
                    document.getElementById("loginSatir").innerHTML = data[i].KullaniciAdi;

                }
            }


        },
        error: function (err) {
        }
    });
}

function exit() {

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/logOut",
        data: {},
        contentType: "application/json;charset=utf-8",
        dataType: "json",

        success: function (result) {
            var data = result.d;

            if (data == "OK") {
                location.href = "login.html";
            }
        },
        error: function (err) {
        }
    });
}

function aktifDiller() {
    $.ajax
         ({
             type: "POST",
             url: "../e-ticaretyonetimdata.asmx/Diller",
             data: {},
             contentType: "application/json;charset=utf-8",
             dataType: "json",
             success: function (result) {
                 if (result.d != "Login") {

                     var myData = JSON.parse(result.d);
                     var data = myData.Table;
                     var myDizayn = "";
                     $("#dil").empty();

                     for (var i = 0; i < data.length; i++) {
                         myDizayn += "<option value='" + data[i].ID + "'>" + data[i].Adi + "</option>";
                     }
                     $("#dil").html(myDizayn);
                 }
                 else {
                     location.href = "index.html";
                 }
             },
             error: function (err) {
                 location.href = "index.html";
             }
         });
}


function diller() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Diller",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {

              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {
                  $("#tabloDil").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {

                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-left'>" + data[i].Adi + "</td><td class='text-left'>Aktif</td><td class='text-right'><a href='#dilGuncelle' onclick='dilBilgi(" + data[i].ID + ");degerAta(" + data[i].ID + ");' data-toggle='modal' title='' class='btn btn-primary' data-original-title='Edit'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else if (data[i].Aktif == "0") {
                          myDizayn += "<tr><td class='text-left'>" + data[i].Adi + "</td><td class='text-left'>Pasif</td><td class='text-right'><a href='#dilGuncelle' onclick='dilBilgi(" + data[i].ID + ");degerAta(" + data[i].ID + ");' data-toggle='modal' title='' class='btn btn-primary' data-original-title='Edit'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                  }

              }
              $("#tabloDil").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function dilEkle() {
    var prm = "{'adi':'" + document.getElementById("dilAdi").value + "','kisaad':'" + document.getElementById("kisaAdi").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/Dilekle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                diller();

                document.getElementById("dilAdi").value = "";
                document.getElementById("kisaAdi").value = "";
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });

}

function dilBilgi(id) {
    var prm = "{'id':'" + id + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/DilBilgi",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var myData = JSON.parse(result.d);
            var data = myData.Table;
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                for (var i = 0; i < data.length; i++) {

                    document.getElementById("dilAdiG").value = data[i].Adi;
                    document.getElementById("kisaAdiG").value = data[i].KisaAdi;
                    document.getElementById("dilDurum").value = data[i].Aktif;
                }
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}

function dilGuncelle() {
    var prm = "{'id':'" + document.getElementById("id").value + "','dilAdi':'" + document.getElementById("dilAdiG").value + "','kisaAdi':'" + document.getElementById("kisaAdiG").value + "','durum':'" + document.getElementById("dilDurum").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/DilGuncelle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                diller();
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });

}


function siteAyarlari() {
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/SiteAyalari",
        data: {},
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var myData = JSON.parse(result.d);
            var data = myData.Table;
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                for (var i = 0; i < data.length; i++) {
                    document.getElementById("googleClientID").value = data[i].GoogleClientID;
                    document.getElementById("googleClientSecret").value = data[i].GoogleClientSecret;
                    document.getElementById("facebookAppID").value = data[i].FacebookAppID;
                    document.getElementById("facebookSecret").value = data[i].FacebookSecret;
                    document.getElementById("twitterApiID").value = data[i].TwitterApiID;
                    document.getElementById("twitterSecret").value = data[i].TwitterSecret;
                    document.getElementById("satisaktif").value = data[i].SatisAktif;
                    document.getElementById("blogaktif").value = data[i].BlogAktif;
                    document.getElementById("uyeliksizsatis").value = data[i].UyeliksizSatis;
                    document.getElementById("uyelikzorunlu").value = data[i].UyelikZorunlu;
                    document.getElementById("dil").value = data[i].DilID;
                }
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });

}

function siteAyarlariGuncelle() {

    var prm = "{'satisAktif':'" + document.getElementById("satisaktif").value + "','blogAktif':'" + document.getElementById("blogaktif").value + "','uyeliksizSatis':'" + document.getElementById("uyeliksizsatis").value + "','uyelikZorunlu':'" + document.getElementById("uyelikzorunlu").value + "','googleClientID':'" + document.getElementById("googleClientID").value + "','googleClientSecret':'" + document.getElementById("googleClientSecret").value + "','facebookAppID':'" + document.getElementById("facebookAppID").value + "','facebookSecret':'" + document.getElementById("facebookSecret").value + "','twitterApiID':'" + document.getElementById("twitterApiID").value + "','twitterSecret':'" + document.getElementById("twitterSecret").value + "','dilID':'" + document.getElementById("dil").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/SiteAyarlariGuncelle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                aktifDiller();
                siteAyarlari();
            }
        },
        error: function (err) {
            //location.href = "index.html";
        }
    });

}

function degerAta(id) {
    document.getElementById("id").value = id;
}

function siteBilgi() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/siteBilgileri",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {

              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {
                  $("#bilgiler").empty();
                  $("#bilgiler").append(result.d);
              }

          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function guncelle(a) {
    var prm = "{'FirmaAdi':'" + document.getElementById("firmaAdi" + a + "").value + "','Adres':'" + document.getElementById("adres" + a + "").value + "','Ulke':'" + document.getElementById("ulke" + a + "").value + "','Sehir':'" + document.getElementById("sehir" + a + "").value + "','Ilce':'" + document.getElementById("ilce" + a + "").value + "','Tel':'" + document.getElementById("tel" + a + "").value + "','Faks':'" + document.getElementById("faks" + a + "").value + "','MobilTel':'" + document.getElementById("mobil" + a + "").value + "','Mail':'" + document.getElementById("mail" + a + "").value + "','URL':'" + document.getElementById("web" + a + "").value + "','KeyWords':'" + document.getElementById("keywords" + a + "").value + "','ID':'" + a + "'}";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/siteBilgiGuncelle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {

            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}


function kategoriler() {

    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Kategoriler",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloKat").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-left'>" + data[i].Adi + "</td><td class='text-center'><a href='#kategoriResimGuncelle' data-toggle='modal' onclick=degerAta('" + data[i].ID + "');resimAta('" + data[i].Resim + "'); data-toggle='modal'><img src='../../Content/img/categories/" + data[i].Resim + "' alt='" + data[i].Adi + ";' class='img-thumbnail' style='width: 50px; height: 50px;'></a></td><td class='text-right'>Aktif</td><td class='text-right'><a href='#kategoriGuncelle' data-toggle='modal' onclick=degerAta('" + data[i].ID + "');kategoriBilgiGetir(); data-toggle='modal' title='' class='btn btn-primary' data-original-title='Düzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-left'>" + data[i].Adi + "</td><td class='text-center'><a><img src='../../Content/img/categories/" + data[i].Resim + "' alt='" + data[i].Adi + ";' class='img-thumbnail' style='width: 50px; height: 50px;'></a><td class='text-right'>Pasif</td><td class='text-right'><a href='#kategoriGuncelle' data-toggle='modal' onclick=degerAta('" + data[i].ID + "');kategoriBilgiGetir(); data-toggle='modal' title='' class='btn btn-primary' data-original-title='Düzenle'><i class='fa fa-pencil'></i></a></td></tr>";

                      }

                  }

              }
              $("#tabloKat").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function kategoriEkle() {
    var prm = "{'adi':'" + document.getElementById("kategoriadi").value + "','aciklama':'" + document.getElementById("aciklama").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/KategoriEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                resimYukle();

            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });

}

function kategoriBilgiGetir() {


    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/Diller",
        contentType: "application/json;charset=utf-8",
        data: {},
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "../index.html";
            }
            else {
                $("#kategoriDil").empty();
                $("#kategoriTab").empty();
                var myData = JSON.parse(result.d);
                var data = myData.Table;
                var myDizayn = "<ul class='nav nav-tabs'>";
                var myDizaynTab = "";

                for (var i = 0; i < data.length; i++) {
                    if (data[i].Aktif == "1") {
                        if (i == 0) {
                            myDizayn += "<li class='active'><a href='#tab" + data[i].Adi + "' data-toggle='tab'>" + data[i].Adi + "</a></li>";
                            myDizaynTab += "<div id='tab" + data[i].Adi + "' class='tab-pane fade active in'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class='col-sm-3 control-label'>Kategori Adı</label><div class='col-sm-8'><input id='kategoriadi" + data[i].ID + "' class='form-control' placeholder='Kategori Adı' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>Açıklama</label><div class='col-sm-8'><input id='aciklama" + data[i].ID + "' class='form-control' placeholder='Açıklama' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>SEO Link</label><div class='col-sm-8'><input id='seoLink" + data[i].ID + "' class='form-control' placeholder='Seo Link' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>Sıra No</label><div class='col-sm-8'><input id='siraNo" + data[i].ID + "' class='form-control' placeholder='Sıra No' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>Durum</label><div class='col-sm-8'><select class='form-control' id='kategoriDurum" + data[i].ID + "'><option value='true'>Aktif</option><option value='false'>Pasif</option></select></div></div></form></div></div></div>";

                        }
                        else {
                            myDizayn += "<li class=''><a href='#tab" + data[i].Adi + "' data-toggle='tab'>" + data[i].Adi + "</a></li>";
                            myDizaynTab += "<div id='tab" + data[i].Adi + "' class='tab-pane fade'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class='col-sm-3 control-label'>Kategori Adı</label><div class='col-sm-8'><input id='kategoriadi" + data[i].ID + "' class='form-control' placeholder='Kategori Adı' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>Açıklama</label><div class='col-sm-8'><input id='aciklama" + data[i].ID + "' class='form-control' placeholder='Açıklama' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>SEO Link</label><div class='col-sm-8'><input id='seoLink" + data[i].ID + "' class='form-control' placeholder='Seo Link' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>Sıra No</label><div class='col-sm-8'><input id='siraNo" + data[i].ID + "' class='form-control' placeholder='Sıra No' type='text'></div></div><div class='form-group'><label class='col-sm-3 control-label'>Durum</label><div class='col-sm-8'><select class='form-control' id='kategoriDurum" + data[i].ID + "'><option value='true'>Aktif</option><option value='false'>Pasif</option></select></div></div></form></div></div></div>";
                        }
                    }

                }

                myDizayn += "</ul>";
                $("#kategoriDil").append(myDizayn);
                $("#kategoriTab").append(myDizaynTab);

                //
                $.ajax({
                    type: "POST",
                    url: "../e-ticaretyonetimdata.asmx/Diller",
                    contentType: "application/json;charset=utf-8",
                    data: {},
                    dataType: "json",
                    success: function (sonuc) {
                        if (sonuc.d == "Login") {
                            location.href = "../index.html";
                        }
                        else {
                            var dt = JSON.parse(sonuc.d);
                            var d = dt.Table;

                            for (var i = 0; i < d.length; i++) {
                                if (d[i].Aktif == "1") {
                                    //
                                    var prm = "{'id':'" + d[i].ID + "','str':'" + document.getElementById("id").value + "'}";
                                    $.ajax({
                                        type: "POST",
                                        url: "../e-ticaretyonetimdata.asmx/kategoriBilgi",
                                        data: prm,
                                        contentType: "application/json;charset=utf-8",
                                        dataType: "json",
                                        success: function (kat) {
                                            var kData = JSON.parse(kat.d);
                                            var k = kData.Table;
                                            if (k.d == "Login") {
                                                location.href = "login.html";
                                            }
                                            else {
                                                for (var i = 0; i < k.length; i++) {
                                                    document.getElementById("kategoriadi" + d[i].ID).value = k[i].Adi;
                                                    document.getElementById("aciklama" + d[i].ID).value = k[i].Aciklama;
                                                    document.getElementById("seoLink" + d[i].ID).value = k[i].Seolink;
                                                    document.getElementById("siraNo" + d[i].ID).value = k[i].SiraNo;
                                                    document.getElementById("kategoriDurum" + d[i].ID).value = k[i].Aktif;
                                                }
                                            }
                                        },
                                        error: function (err) {
                                            location.href = "index.html";
                                        }
                                    });
                                    //
                                }

                            }

                        }
                    },
                    error: function (err) {
                        location.href = "../index.html";
                    }
                });
                //
            }
        },
        error: function (err) {
            location.href = "../index.html";
        }
    });
}

function kategoriGuncelle() {

    var prm = "";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/Diller",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var myData = JSON.parse(result.d);
            var data = myData.Table;
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                for (var i = 0; i < data.length; i++) {
                    prm = "{'did':'" + data[i].ID + "','kid':'" + document.getElementById("id").value + "','adi':'" + document.getElementById("kategoriadi" + data[i].ID + "").value + "','aciklama':'" + document.getElementById("aciklama" + data[i].ID + "").value + "','seolink':'" + document.getElementById("seoLink" + data[i].ID + "").value + "','siraNo':'" + document.getElementById("siraNo" + data[i].ID + "").value + "','durum':'" + document.getElementById("kategoriDurum" + data[i].ID + "").value + "'}";
                    $.ajax({
                        type: "POST",
                        url: "../e-ticaretyonetimdata.asmx/KategoriGuncelle",
                        data: prm,
                        contentType: "application/json;charset=utf-8",
                        dataType: "json",
                        success: function (result) {
                            if (result.d == "Login") {
                                location.href = "login.html";
                            }
                            else {
                            }
                        },
                        error: function (err) {
                            location.href = "index.html";
                        }
                    });
                }
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });




}

function urunKategorileri() {
    $.ajax
         ({
             type: "POST",
             url: "../e-ticaretyonetimdata.asmx/UrunKategorileri",
             data: {},
             contentType: "application/json;charset=utf-8",
             dataType: "json",
             success: function (result) {
                 if (result.d != "Login") {

                     var myData = JSON.parse(result.d);
                     var data = myData.Table;
                     var myDizayn = "";
                     $("#kategori").empty();
                     $("#kategorilerUst").empty();
                     //myDizayn += "<option value='0'>Kategori Seç</option>";
                     for (var i = 0; i < data.length; i++) {
                         myDizayn += "<option value='" + data[i].ID + "'>" + data[i].Adi + "</option>";
                     }
                     $("#kategori").html(myDizayn);
                     $("#kategorilerUst").html(myDizayn);
                 }
                 else {
                     location.href = "index.html";
                 }
             },
             error: function (err) {
                 location.href = "index.html";
             }
         });
}

function kategoriDurumGuncelle(a) {
    $("input[name='chk']:checked").each(function () {
        var prm = "{'id' :'" + $(this).val() + "','durum' :'" + a + "'}";
        $.ajax
          ({
              type: "POST",
              url: "../e-ticaretyonetimdata.asmx/KategoriDurumGuncelle",
              data: prm,
              contentType: "application/json;charset=utf-8",
              dataType: "json",
              success: function (result) {
                  if (result.d == "Login") {
                      location.href = "index.html";
                  }
                  else {

                  }
              },
              error: function (err) {
                  location.href = "index.html";
              }
          });
    });

}

function urunler() {
    var prm = "{'id':'" + document.getElementById("kategorilerUst").value + "'}", myDizayn = "0";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Urunler",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloUrunler").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value=''" + data[i].ID + "''></td><td class='text-center'> <img src='../../Content/img/product-img/small/" + data[i].Resim + "' alt='" + data[i].UrunAdi + ";' class='img-thumbnail' style='width: 50px; height: 50px;'> </td><td class='text-left'>" + data[i].UrunAdi + "</td><td class='text-left'>" + data[i].UrunKodu + "</td><td class='text-right'> <span class='label label-success'>" + data[i].Fiyat + "</span> </td><td class='text-left'>Aktif</td><td class='text-right'><a href='javascript:void(0);' onclick=degerAta('" + data[i].ID + "');dosyaOku('../Admin/documan/urunduzenleme.html'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Düzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value=''" + data[i].ID + "''></td><td class='text-center'> <img src='../../Content/img/product-img/small/" + data[i].Resim + "' alt='" + data[i].UrunAdi + ";' class='img-thumbnail'  style='width: 50px; height: 50px;'> </td><td class='text-left'>" + data[i].UrunAdi + "</td><td class='text-left'>" + data[i].UrunKodu + "</td><td class='text-right'> <span class='label label-success'>" + data[i].Fiyat + "</span> </td><td class='text-left'>Pasif</td><td class='text-right'><a href='javascript:void(0);' onclick=degerAta('" + data[i].ID + "');dosyaOku('../Admin/documan/urunduzenleme.html'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Düzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                  }
              }
              $("#tabloUrunler").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function urunlerKategori() {
    var prm = "{'id':'" + document.getElementById("kategorilerUst").value + "'}", myDizayn = "0";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/UrunlerKategoriyeGore",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloUrunler").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value=''" + data[i].ID + "''></td><td class='text-center'> <img src='../../Content/img/product-img/small/" + data[i].Resim + "' alt='" + data[i].UrunAdi + ";' class='img-thumbnail' style='width: 50px; height: 50px;'> </td><td class='text-left'>" + data[i].UrunAdi + "</td><td class='text-left'>" + data[i].UrunKodu + "</td><td class='text-right'> <span class='label label-success'>" + data[i].Fiyat + "</span> </td><td class='text-left'>Aktif</td><td class='text-right'><a href='javascript:void(0);' onclick=degerAta('" + data[i].ID + "');dosyaOku('../Admin/documan/urunduzenleme.html'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Düzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value=''" + data[i].ID + "''></td><td class='text-center'> <img src='../../Content/img/product-img/small/" + data[i].Resim + "' alt='" + data[i].UrunAdi + ";' class='img-thumbnail'  style='width: 50px; height: 50px;'> </td><td class='text-left'>" + data[i].UrunAdi + "</td><td class='text-left'>" + data[i].UrunKodu + "</td><td class='text-right'> <span class='label label-success'>" + data[i].Fiyat + "</span> </td><td class='text-left'>Pasif</td><td class='text-right'><a href='javascript:void(0);' onclick=degerAta('" + data[i].ID + "');dosyaOku('../Admin/documan/urunduzenleme.html'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Düzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                  }
              }
              $("#tabloUrunler").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function sumerNoteAyarlar() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Diller",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  var deger = 0;
                  for (var i = 1; i <= data.length; i++) {
                      deger = i;
                      $('#summernote' + i).summernote({
                          height: 300,
                          minHeight: null,
                          maxHeight: null,
                          focus: true
                      });
                  }
              }
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function urunTeknikBilgilerDillereGore() {


    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/Diller",
        contentType: "application/json;charset=utf-8",
        data: {},
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "../index.html";
            }
            else {
                $("#teknikTabDil").empty();
                $("#teknikTab").empty();
                var myData = JSON.parse(result.d);
                var data = myData.Table;
                var myDizayn = "";
                var myDizaynTab = "";

                for (var i = 0; i < data.length; i++) {
                    if (data[i].Aktif == "1") {
                        if (i == 0) {
                            myDizayn += "<li class='active'><a href='#tab" + data[i].Adi + "' data-toggle='tab'>" + data[i].Adi + "</a></li>";
                            myDizaynTab += "<div id='teknikDetay" + data[i].Adi + "' class='tab-pane fade active in'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class='col-sm-2 control-label'>Açıklama</label><div class='col-sm-10'><div id='teknikAciklama" + data[i].ID + "'></div></div></div><div class='form-group'><label class='col-sm-2 control-label'>Açıklam Devam<span class='text-danger'> * </span></label><div class='col-sm-10'><div id='teknikAciklamaDevam" + data[i].ID + "'></div></div></div><div class='form-group'><label class='col-sm-2 control-label'>Teknik Detay <span class='text-danger'> * </span></label><div class='col-sm-10'><div id='teknikDetay" + data[i].ID + "'></div></div></div></form></div></div></div>";

                        }
                        else {
                            myDizayn += "<li class=''><a href='#tab" + data[i].Adi + "' data-toggle='tab'>" + data[i].Adi + "</a></li>";
                            myDizaynTab += "<div id='teknikDetay" + data[i].Adi + "' class='tab-pane fade'><div class='row'><div class='col-md-12'><form class='form-horizontal' role='form'><div class='form-group'><label class='col-sm-2 control-label'>Açıklama</label><div class='col-sm-10'><div id='teknikAciklama" + data[i].ID + "'></div></div></div><div class='form-group'><label class='col-sm-2 control-label'>Açıklam Devam<span class='text-danger'> * </span></label><div class='col-sm-10'><div id='teknikAciklamaDevam" + data[i].ID + "'></div></div></div><div class='form-group'><label class='col-sm-2 control-label'>Teknik Detay <span class='text-danger'> * </span></label><div class='col-sm-10'><div id='teknikDetay" + data[i].ID + "'></div></div></div></form></div></div></div>";
                        }
                    }

                }

                $("#teknikTabDil").append(myDizayn);
                $("#teknikTab").append(myDizaynTab);

                for (var i = 0; i < data.length; i++) {
                    if (data[i].Aktif == "1") {
                        //
                        var prm = "{'id':'" + data[i].ID + "','str':'" + document.getElementById("id").value + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../e-ticaretyonetimdata.asmx/UrunTeknikDetayi",
                            data: prm,
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            success: function (kat) {
                                var kData = JSON.parse(kat.d);
                                var k = kData.Table;
                                if (k.d == "Login") {
                                    location.href = "login.html";
                                }
                                else {
                                    for (var i = 0; i < k.length; i++) {

                                        $("#teknikAciklama" + data[i].ID).html(k[i].TeknikAciklama);
                                        $("#teknikAciklamaDevam" + data[i].ID).html(k[i].TeknikAciklamaDevam);
                                        $("#teknikDetay" + data[i].ID).html(k[i].TeknikDetay);

                                        $('#teknikAciklama' + data[i].ID).summernote({
                                            height: 300,
                                            minHeight: null,
                                            maxHeight: null,
                                            focus: true
                                        });
                                        $('#teknikAciklamaDevam' + data[i].ID).summernote({
                                            height: 300,
                                            minHeight: null,
                                            maxHeight: null
                                        });
                                        $('#teknikDetay' + data[i].ID).summernote({
                                            height: 300,
                                            minHeight: null,
                                            maxHeight: null
                                        });
                                    }
                                }
                            },
                            error: function (err) {
                                location.href = "index.html";
                            }
                        });
                        //
                    }

                }


            }
        },
        error: function (err) {
            location.href = "../index.html";
        }
    });
}

function urunBilgi() {
    var prm = "{'id':'" + document.getElementById("id").value + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/UrunDetayi",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tab1").empty();
                  $("#tab1").append(result.d);
                  sumerNoteAyarlar();

              }
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function urunResimleri() {
    var prm = "{'id':'" + document.getElementById("id").value + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/UrunResimleriIDile",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#urunResimleri").empty();
                  $("#urunResimleri").append(result.d);


              }
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function urunBilgiGuncelleUrunlerTablosu() {
    prm = "{'uid':'" + document.getElementById("id").value + "','kid':'" + document.getElementById("kategori").value + "','mid':'" + document.getElementById("markalar").value + "','modelNo':'" + document.getElementById("modelAdi").value + "','barkod':'" + document.getElementById("barkod").value + "','durum':'" + document.getElementById("durum").value + "'}";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/UrunGuncelleUrunlerTablosu",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {

            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });

}

function urunGuncelle() {

    if (document.getElementById('kategori').value != "0") {
        var prm = "";

        urunBilgiGuncelleUrunlerTablosu();
        urunResimYukle();
        $.ajax({
            type: "POST",
            url: "../e-ticaretyonetimdata.asmx/Diller",
            data: prm,
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                var myData = JSON.parse(result.d);
                var data = myData.Table;
                if (result.d == "Login") {
                    location.href = "login.html";
                }
                else {
                    for (var i = 0; i < data.length; i++) {
                        prm = "{'uid':'" + document.getElementById("id").value + "','did':'" + data[i].ID + "','adi':'" + document.getElementById("urunAdi" + data[i].ID + "").value + "','aciklama':'" + $('#summernote' + data[i].ID).summernote('code') + "','siraNo':'" + document.getElementById("urunSirasi" + data[i].ID + "").value + "','seo':'" + document.getElementById("seo" + data[i].ID + "").value + "','fiyat':'" + document.getElementById("urunFiyati" + data[i].ID + "").value + "','kdv':'" + document.getElementById("kdv" + data[i].ID + "").value + "','metaTit':'" + document.getElementById("metaTitle" + data[i].ID + "").value + "','metaKey':'" + document.getElementById("metaKey" + data[i].ID + "").value + "','metaDes':'" + document.getElementById("metaDesc" + data[i].ID + "").value + "','teknikAciklama':'" + $('#teknikAciklama' + data[i].ID).summernote('code') + "','teknikAciklamaDevam':'" + $('#teknikAciklamaDevam' + data[i].ID).summernote('code') + "','teknikDetay':'" + $('#teknikDetay' + data[i].ID).summernote('code') + "'}";
                        $.ajax({
                            type: "POST",
                            url: "../e-ticaretyonetimdata.asmx/UrunGuncelleUrunlerDilTablosu",
                            data: prm,
                            contentType: "application/json;charset=utf-8",
                            dataType: "json",
                            success: function (result) {
                                if (result.d == "Login") {
                                    location.href = "login.html";
                                }
                                else {
                                }
                            },
                            error: function (err) {
                                location.href = "index.html";
                            }
                        });

                    }
                }
            },
            error: function (err) {
                location.href = "index.html";
            }
        });
    }
    else {
        alert("Bilgiler Sekmesinde Kategori Seçimi Yapınız..");
    }

}

function urunEkle() {
    var prm = "{'kid':'" + document.getElementById("kategori").value + "','mid':'" + document.getElementById("markalar").value + "','adi':'" + document.getElementById("urunAdi").value + "','aciklama':'" + $('#summernote').summernote('code') + "','metatit':'" + document.getElementById("metaTitle").value + "','metakey':'" + document.getElementById("metaKey").value + "','metades':'" + document.getElementById("metaDesc").value + "','modelNo':'" + document.getElementById("modelAdi").value + "','stokKodu':'" + document.getElementById("sku").value + "','barkod':'" + document.getElementById("barkod").value + "','fiyat':'" + document.getElementById("fiyat").value + "','kdv':'" + document.getElementById("kdv").value + "','durum':'" + document.getElementById("durum").value + "','siraNo':'" + document.getElementById("siraNo").value + "'}";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/UrunEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                if (result.d == "Aynı İsimle İkinci Ürün Eklenemez..") {
                    alert("Aynı İsimle Birden Fazla Ürün Kaydı Yapılamaz..");
                } else {
                    urunResimYukle();
                    dosyaOku('../Admin/documan/urunler.html');
                }
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}

function urunResimYukle() {

    var fileInput = document.getElementById("resim");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYukleUrun",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }

    }

}

function sil(a, str, b) {
    var prm = "{'id' :'" + a + "','str' :'" + str + "','deger' :'" + str + "','str' :'" + str + "','kolon' :'" + b + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/DurumGuncelle",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "../index.html";
              }
              else {
                  kategoriler();
              }
          },
          error: function (err) {
              location.href = "../index.html";
          }
      });
}

function kategoriResimGuncelle() {

    var prm = "{'id':'" + document.getElementById('id').value + "'}";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/kategoriIDAta",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {

                kategoriResimYukleGuncelle();
                kategoriler();
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });

}

function kategoriResimYukleGuncelle() {

    var fileInput = document.getElementById("resimG");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/kategoriResimGuncelle",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }

    }

}

function resimYukle() {

    var fileInput = document.getElementById("resim");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYukleKategori",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }
        kategoriler();

    }

}

function resimYukleMarka() {

    var fileInput = document.getElementById("resimG");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYukleMarka",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }

    }

}

function resimYuklePromosyon() {

    var fileInput = document.getElementById("resimG");
    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYuklePromosyon",
                contentType: false,
                processData: false,
                data: formData


            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert(xhr + "  " + textStatus);
            });
        }

    }

}

function resimYeniMarka() {

    var fileInput = document.getElementById("resim");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYukleMarka",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }

    }

}

function resimYeniSlider() {

    var fileInput = document.getElementById("resim");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYukleSlider",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }

    }

}

function resimSliderGuncelle() {

    var fileInput = document.getElementById("resimG");

    if (fileInput.multiple == true) {

        for (var i = 0, len = fileInput.files.length; i < len; i++) {
            var formData = new FormData();
            formData.append("UploadedImage", fileInput.files.item(i));
            var ajaxRequest = $.ajax({
                type: "POST",
                url: "../e-ticaretyonetimdata.asmx/resimYukleSliderGuncelle",
                contentType: false,
                processData: false,
                data: formData

            });

            ajaxRequest.done(function (xhr, textStatus) {
                //alert("Resim Yüklemede hata");
            });
        }

    }

}

function slider() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Sliderlar",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloSlider").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-left'> <img src='../../Content/img/slide-img/" + data[i].Resim + "' alt='" + data[i].Adi + "' class='img-thumbnail' style='width: 15%;'> </td><td class='text-left'>" + data[i].Adi + "</td><td class='text-left'>" + data[i].URL + "</td><td class='text-left'>Aktif</td><td class='text-right'><a href='#sliderDuzenle' data-toggle='modal' onclick=sliderBilgi('" + data[i].ID + "');degerAta('" + data[i].ID + "'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Duzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-left'> <img src='../../Content/img/slide-img/" + data[i].Resim + "' alt='" + data[i].Adi + "' class='img-thumbnail' style='width: 15%;'> </td><td class='text-left'>" + data[i].Adi + "</td><td class='text-left'>" + data[i].URL + "</td><td class='text-left'>Pasif</td><td class='text-right'><a href='#sliderDuzenle' data-toggle='modal' onclick=sliderBilgi('" + data[i].ID + "');degerAta('" + data[i].ID + "'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Duzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }

                  }

              }
              $("#tabloSlider").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function sliderBilgi(id) {
    var prm = "{'id':'" + id + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/SliderBilgi",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;
                  for (var i = 0; i < data.length; i++) {

                      document.getElementById("sliderAdiG").value = data[i].Adi;
                      document.getElementById("sliderMetinG").value = data[i].BaslikIcerik;
                      document.getElementById("sliderMetinEkG").value = data[i].BaslikEk;
                      document.getElementById("butonMetinG").value = data[i].ButtonName;
                      document.getElementById("urlG").value = data[i].URL;
                      document.getElementById("sliderDurumG").value = data[i].Aktif;
                      document.getElementById("sliderResmiG").src = "../../Content/img/slide-img/" + data[i].Resim;

                  }


              }
          },
          error: function (err) {

              location.href = "login.html";
          }
      });

}

function sliderEkle() {
    var prm = "{'ad':'" + document.getElementById("sliderAdi").value + "','baslikM':'" + document.getElementById("sliderMetin").value + "','baslikE':'" + document.getElementById("sliderMetinEk").value + "','button':'" + document.getElementById("butonMetin").value + "','url':'" + document.getElementById("url").value + "','durum':'" + document.getElementById("sliderDurum").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/SliderEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                document.getElementById("sliderAdi").value = "";
                document.getElementById("sliderMetin").value = "";
                document.getElementById("sliderMetinEk").value = "";
                document.getElementById("butonMetin").value = "";
                document.getElementById("url").value = "";
                resimYeniSlider();
                slider();

            }
        },
        error: function (err) {
            //location.href = "index.html";
        }
    });
}

function sliderGuncelle() {
    var prm = "{'id':'" + document.getElementById('id').value + "','ad':'" + document.getElementById('sliderAdiG').value + "','baslikM':'" + document.getElementById('sliderMetinG').value + "','baslikE':'" + document.getElementById('sliderMetinEkG').value + "','button':'" + document.getElementById('butonMetinG').value + "','url':'" + document.getElementById('urlG').value + "','durum':'" + document.getElementById('sliderDurumG').value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/SliderGuncelle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {

                resimSliderGuncelle();
                slider();
                document.getElementById('id').value = "0";
                document.getElementById("sliderAdiG").value = "";
                document.getElementById("sliderMetinG").value = "";
                document.getElementById("sliderMetinEkG").value = "";
                document.getElementById("butonMetinG").value = "";
                document.getElementById("urlG").value = "";
                document.getElementById("sliderDurumG").value = "";
                document.getElementById("sliderResmiG").src = "";
                document.getElementById("resimG").value = "";

            }
        },
        error: function (err) {
            alert(err);
            //location.href = "index.html";
        }
    });


}

function promasyonlar() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Promosyonlar",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloPromasyon").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;



                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-center'> <img src='../../Content/img/banner/" + data[i].Resim + "' alt='" + data[i].Adi + "' class='img-thumbnail' style='width: 50%;'> </td><td class='text-left'>" + data[i].Adi + "</td><td class='text-left'>Aktif</td><td class='text-right'><a href='#promasyonDuzenle' data-toggle='modal' onclick=promasyonBilgi('" + data[i].ID + "');degerAta('" + data[i].ID + "'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Duzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-center'> <img src='../../Content/img/banner/" + data[i].Resim + "' alt='" + data[i].Adi + "' class='img-thumbnail' style='width: 50%;'> </td><td class='text-left'>" + data[i].Adi + "</td><td class='text-left'>Pasif</td><td class='text-right'><a href='#promasyonDuzenle' data-toggle='modal' onclick=promasyonBilgi('" + data[i].ID + "');degerAta('" + data[i].ID + "'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Duzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }

                  }

              }
              $("#tabloPromasyon").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function promasyonBilgi(id) {
    var prm = "{'id':'" + id + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/PromosyonBilgi",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var myData = JSON.parse(result.d);
            var data = myData.Table;
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                for (var i = 0; i < data.length; i++) {
                    document.getElementById("promasyonAdi").value = data[i].Adi;
                    document.getElementById("url").value = data[i].URL;
                    document.getElementById("promasyonResmi").src = "../../Content/img/banner/" + data[i].Resim;
                    document.getElementById("promasyonDurum").value = data[i].Aktif;
                }
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}

function promasyonGuncelle() {
    var prm = "{'id':'" + document.getElementById('id').value + "','adi':'" + document.getElementById('promasyonAdi').value + "','url':'" + document.getElementById('url').value + "','durum':'" + document.getElementById('promasyonDurum').value + "'}";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/PromosyonGuncelle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {

                resimYuklePromosyon();
                document.getElementById('id').value = "0";
                document.getElementById('promasyonAdi').value = "";
                document.getElementById('url').value = "";
                document.getElementById('promasyonDurum').value = "";
                promasyonlar();
            }
        },
        error: function (err) {
            alert(err);
            //location.href = "index.html";
        }
    });
}

function markaEkle() {

    var prm = "{'markaAdi':'" + document.getElementById("markaAdi").value + "','siraNo':'" + document.getElementById("siralama").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/MarkaEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                document.getElementById("siralama").value = "";
                document.getElementById("markaAdi").value = "";
                resimYeniMarka();
                markalar();

            }
        },
        error: function (err) {
            //location.href = "index.html";
        }
    });
}

function markalariGetir() {
    $.ajax
         ({
             type: "POST",
             url: "../e-ticaretyonetimdata.asmx/Markalar",
             data: {},
             contentType: "application/json;charset=utf-8",
             dataType: "json",
             success: function (result) {
                 if (result.d != "Login") {

                     var myData = JSON.parse(result.d);
                     var data = myData.Table;
                     var myDizayn = "";
                     $("#markalar").empty();
                     //myDizayn += "<option value='0'>Marka Seç</option>";
                     for (var i = 0; i < data.length; i++) {
                         myDizayn += "<option value='" + data[i].ID + "'>" + data[i].MarkaAdi + "</option>";
                     }
                     $("#markalar").html(myDizayn);
                 }
                 else {
                     location.href = "index.html";
                 }
             },
             error: function (err) {
                 location.href = "index.html";
             }
         });
}

function markalar() {
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/Markalar",
          data: {},
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloMarkalar").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;



                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-center'> <img src='../../Content/img/logo/kucuk/" + data[i].Resim + "' alt='" + data[i].MarkaAdi + "' class='img-thumbnail' style='width: 50px; height: 50px;'> </td><td class='text-left'>" + data[i].MarkaAdi + "</td><td class='text-left'>Aktif</td><td class='text-right'><a href='#markaDuzenle' data-toggle='modal' onclick=markaBilgi('" + data[i].ID + "');degerAta('" + data[i].ID + "'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Duzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-center'><input type='checkbox' name='chk' value='" + data[i].ID + "'></td><td class='text-center'> <img src='../../Content/img/logo/kucuk/" + data[i].Resim + "' alt='" + data[i].MarkaAdi + "' class='img-thumbnail' style='width: 50px; height: 50px;'> </td><td class='text-left'>" + data[i].MarkaAdi + "</td><td class='text-left'>Pasif</td><td class='text-right'><a href='#markaDuzenle' data-toggle='modal' onclick=markaBilgi('" + data[i].ID + "');degerAta('" + data[i].ID + "'); data-toggle='tooltip' title='' class='btn btn-primary' data-original-title='Duzenle'><i class='fa fa-pencil'></i></a></td></tr>";
                      }

                  }

              }
              $("#tabloMarkalar").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function markaBilgi(id) {
    var prm = "{'id':'" + id + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/MarkaBilgi",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var myData = JSON.parse(result.d);
            var data = myData.Table;
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                for (var i = 0; i < data.length; i++) {

                    document.getElementById("markaAdiG").value = data[i].MarkaAdi;
                    document.getElementById("siraNoG").value = data[i].SiraNo;
                    document.getElementById("markaResmiG").src = "../../Content/img/logo/" + data[i].Resim;
                    document.getElementById("markaDurum").value = data[i].Aktif;
                }
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}

function markaGuncelle() {
    var prm = "{'id':'" + document.getElementById('id').value + "','markaAdi':'" + document.getElementById('markaAdiG').value + "','siraNo':'" + document.getElementById('siraNoG').value + "','durum':'" + document.getElementById('markaDurum').value + "','resim':'" + document.getElementById('resim').value + "'}";

    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/MarkaGuncelle",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {

                resimYukleMarka();

                document.getElementById('id').value = "0";
                document.getElementById('markaAdiG').value = "";
                document.getElementById('siraNoG').value = "";
                document.getElementById('markaDurum').value = "";
                markalar();
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}

function markaSil() {
    $("input[name='chk']:checked").each(function () {
        var prm = "{'id' :'" + $(this).val() + "'}";
        $.ajax
          ({
              type: "POST",
              url: "../e-ticaretyonetimdata.asmx/MarkaSil",
              data: prm,
              contentType: "application/json;charset=utf-8",
              dataType: "json",
              success: function (result) {
                  if (result.d == "Login") {
                      location.href = "../index.html";
                  }
                  else {
                  }
              },
              error: function (err) {
                  location.href = "../index.html";
              }
          });
    });
    markalar();
}

function kategoriSil() {
    $("input[name='chk']:checked").each(function () {
        var prm = "{'id' :'" + $(this).val() + "'}";
        $.ajax
          ({
              type: "POST",
              url: "../e-ticaretyonetimdata.asmx/KategoriSil",
              data: prm,
              contentType: "application/json;charset=utf-8",
              dataType: "json",
              success: function (result) {
                  if (result.d == "Login") {
                      location.href = "../index.html";
                  }
                  else {
                  }
              },
              error: function (err) {
                  location.href = "../index.html";
              }
          });
    });
}

function bedenler() {
    var prm = "{'id':'" + document.getElementById('id').value + "'}";

    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/BedenlerIDile",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloBedenler").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;



                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-left'>" + data[i].BedenAdi + "</td><td class='text-right'> Aktif</td><td class='text-right'><button type='button' onclick='bedenSil(" + data[i].ID + ");' data-toggle='tooltip' title='' class='btn btn-danger' data-original-title='Remove'><i class='fa fa-minus-circle'></i></button></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-left'>" + data[i].BedenAdi + "</td><td class='text-right'> Pasif</td><td class='text-right'><button type='button' onclick='bedenSil(" + data[i].ID + ");' data-toggle='tooltip' title='' class='btn btn-danger' data-original-title='Remove'><i class='fa fa-minus-circle'></i></button></td></tr>";
                      }

                  }

              }
              $("#tabloBedenler").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function bedenEkle() {

    var prm = "{'id':'" + document.getElementById("id").value + "','bedenAdi':'" + document.getElementById("bedenAdi").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/BedenEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                document.getElementById("bedenAdi").value = "";
                bedenler();
            }
        },
        error: function (err) {
            //location.href = "index.html";
        }
    });
}

function bedenSil(id) {
    var prm = "{'id' :'" + id + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/BedenSil",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "../index.html";
              }
              else {
                  bedenler();
              }
          },
          error: function (err) {
              location.href = "../index.html";
          }
      });

    markalar();
}

function renkler() {
    var prm = "{'id':'" + document.getElementById('id').value + "'}";

    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/RenklerIDile",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloRenkler").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;



                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {
                      if (data[i].Aktif == "1") {
                          myDizayn += "<tr><td class='text-left'> " + data[i].RenkAdi + "</td><td class='text-right'> " + data[i].RenkKodu + " </td><td class='text-right'> Aktif</td><td class='text-right'><button type='button' onclick='renkSil(" + data[i].ID + ");' data-toggle='tooltip' title='' class='btn btn-danger' data-original-title='Remove'><i class='fa fa-minus-circle'></i></button></td></tr>";
                      }
                      else {
                          myDizayn += "<tr><td class='text-left'> " + data[i].RenkAdi + "</td><td class='text-right'> " + data[i].RenkKodu + " </td><td class='text-right'> Pasif</td><td class='text-right'><button type='button' onclick='renkSil(" + data[i].ID + ");' data-toggle='tooltip' title='' class='btn btn-danger' data-original-title='Remove'><i class='fa fa-minus-circle'></i></button></td></tr>";
                      }

                  }

              }
              $("#tabloRenkler").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function renkEkle() {

    var prm = "{'id':'" + document.getElementById("id").value + "','renkAdi':'" + document.getElementById("renkAdi").value + "','renkKodu':'" + document.getElementById("renkKodu").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/RenkEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                document.getElementById("renkAdi").value = "";
                renkler();
            }
        },
        error: function (err) {
            //location.href = "index.html";
        }
    });
}

function renkSil(id) {
    var prm = "{'id' :'" + id + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/RenkSil",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "../index.html";
              }
              else {
                  renkler();
              }
          },
          error: function (err) {
              location.href = "../index.html";
          }
      });

    markalar();
}

function etiketler() {
    var prm = "{'id':'" + document.getElementById('id').value + "'}";

    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/EtiketlerIDile",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "login.html";
              }
              else {

                  $("#tabloEtiketler").empty();
                  var myData = JSON.parse(result.d);
                  var data = myData.Table;



                  var myDizayn = "";
                  for (var i = 0; i < data.length; i++) {

                      myDizayn += "<tr><td class='text-left'> " + data[i].Adi + "</td><td class='text-right'><button type='button' onclick='etiketSil(" + data[i].ID + ");' data-toggle='tooltip' title='' class='btn btn-danger' data-original-title='Remove'><i class='fa fa-minus-circle'></i></button></td></tr>";


                  }

              }
              $("#tabloEtiketler").append(myDizayn);
          },
          error: function (err) {

              location.href = "login.html";
          }
      });
}

function etiketEkle() {

    var prm = "{'id':'" + document.getElementById("id").value + "','etiket':'" + document.getElementById("etiket").value + "'}";
    $.ajax({
        type: "POST",
        url: "../e-ticaretyonetimdata.asmx/EtiketEkleme",
        data: prm,
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.d == "Login") {
                location.href = "login.html";
            }
            else {
                document.getElementById("etiket").value = "";
                etiketler();
            }
        },
        error: function (err) {
            location.href = "index.html";
        }
    });
}

function etiketSil(id) {
    var prm = "{'uid':'" + document.getElementById("id").value + "','eid':'" + id + "'}";
    $.ajax
      ({
          type: "POST",
          url: "../e-ticaretyonetimdata.asmx/EtiketSil",
          data: prm,
          contentType: "application/json;charset=utf-8",
          dataType: "json",
          success: function (result) {
              if (result.d == "Login") {
                  location.href = "../index.html";
              }
              else {
                  etiketler();
              }
          },
          error: function (err) {
              location.href = "../index.html";
          }
      });

    markalar();
}