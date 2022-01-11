import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:flutter_login/models/HairSalon.dart';
import 'package:flutter_login/models/application_user.dart';
import 'package:flutter_login/models/hairdress.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus.dart';
import 'package:flutter_login/models/loyalty_bonus/loyalty_bonus_search_request.dart';
import 'package:flutter_login/models/review/review.dart';
import 'package:flutter_login/models/review/review_insert_request.dart';
import 'package:flutter_login/models/review/review_search_request.dart';
import 'package:flutter_login/pages/loyalty.dart';
import 'package:flutter_login/pages/loyalty_bonus_page.dart';
import 'package:flutter_login/models/hairsalon_hairdresser/hairsalon_hairdresser.dart';
import 'package:flutter_login/models/hairsalon_hairdresser/hairsalon_hairdresser_search.dart';
import 'package:flutter_login/services/api_service.dart';
import 'package:flutter_login/widget/custom_list_title.dart';
import 'package:flutter_svg/svg.dart';
import 'package:google_fonts/google_fonts.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'calendar_page.dart';
import 'package:percent_indicator/percent_indicator.dart';

class Details extends StatefulWidget {
  final HairSalon hairSalon;
  final ApplicationUser user;
  const Details(this.hairSalon, this.user, {Key? key}) : super(key: key);

  @override
  _DetailsState createState() => _DetailsState(hairSalon, user);
}

class _DetailsState extends State<Details> {
  final HairSalon hairsalon;
  final ApplicationUser user;
  final icon = CupertinoIcons.moon_stars;
  final String assetName = 'assets/hairdresser.svg';

  _DetailsState(this.hairsalon, this.user);

  var request = null;
  var reviewRequest = null;
  var loyaltyRequest = null;

  @override
  void initState() {
    super.initState();
    request =
        HairSalonHairDresserSearchRequest(hairsalonId: hairsalon.HairSalonId);
    reviewRequest = ReviewSearchRequest(hairsalonId: hairsalon.HairSalonId);
    loyaltyRequest = LoyaltyBonusSearchRequest(hairSalonId: hairsalon.HairSalonId);
  }

  var ratingRasult = null;
  var ratingRequest = null;
  Future<void> _setRating(rating) async {
    ratingRequest = ReviewInsertRequest(
        hairSalonId: hairsalon.HairSalonId,
        clientId: user.applicationUserId,
        starrating: rating.toInt());
    ratingRasult = await APIService.post("Review", ratingRequest);
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: BackButton(color: Colors.blue),
        centerTitle: true,
        title: Text(
          "Details",
          style: GoogleFonts.pacifico(color: Colors.black),
        ),
        backgroundColor: Colors.white,
        elevation: 0,
        actions: [
          IconButton(
            icon: Icon(icon),
            color: Colors.blue,
            onPressed: () {},
          ),
        ],
      ),
      body: ListView(
        children: <Widget>[
          SizedBox(height: 10.0),
          Container(
            padding: EdgeInsets.only(left: 20),
            height: 250.0,
            child: ListView(
              padding: EdgeInsets.only(right: 10.0),
              children: <Widget>[
                Padding(
                  padding: EdgeInsets.only(right: 10.0),
                  child: ClipRRect(
                    borderRadius: BorderRadius.circular(10.0),
                    child: Ink.image(
                      image: NetworkImage(
                        'https://i.pinimg.com/originals/c5/5a/de/c55ade0f3c23b62ff5b7eb6af21ecdc6.jpg',
                      ),
                      height: 240,
                      fit: BoxFit.cover,
                    ),
                  ),
                )
              ],
            ),
          ),
          SizedBox(height: 20),
          ListView(
            padding: EdgeInsets.symmetric(horizontal: 20),
            physics: NeverScrollableScrollPhysics(),
            primary: false,
            shrinkWrap: true,
            children: <Widget>[
              Column(
                children: <Widget>[
                  Container(
                    alignment: Alignment.centerLeft,
                    child: Text(
                      hairsalon.Name,
                      style: TextStyle(
                        fontWeight: FontWeight.w700,
                        fontSize: 20,
                      ),
                      maxLines: 2,
                      textAlign: TextAlign.left,
                    ),
                  ),
                  SizedBox(height: 5),
                  Row(
                    children: <Widget>[
                      Icon(
                        Icons.location_on,
                        size: 14,
                        color: Colors.blueGrey[300],
                      ),
                      SizedBox(width: 3),
                      Container(
                        alignment: Alignment.centerLeft,
                        child: Text(
                          hairsalon.Address,
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 13,
                            color: Colors.blueGrey[300],
                          ),
                          maxLines: 1,
                          textAlign: TextAlign.center,
                        ),
                      ),
                    ],
                  ),
                  SizedBox(height: 20),
                  starWidget(),
                ],
              ),
              SizedBox(height: 40),
              Container(
                alignment: Alignment.centerLeft,
                child: Text(
                  "Details",
                  style: TextStyle(
                    fontWeight: FontWeight.bold,
                    fontSize: 16,
                  ),
                  maxLines: 1,
                  textAlign: TextAlign.left,
                ),
              ),
              SizedBox(height: 10),
              Container(
                alignment: Alignment.centerLeft,
                child: Text(
                  hairsalon.Description,
                  style: TextStyle(
                    fontWeight: FontWeight.normal,
                    fontSize: 15.0,
                  ),
                  textAlign: TextAlign.left,
                ),
              ),
              SizedBox(height: 30.0),
              CustomListTitle(title: "Pick your hairdresser"),
              SizedBox(height: 15.0),
              Container(
                width: double.infinity,
                height: 90,
                child: listHairDresser(),
              ),
              SizedBox(height: 30.0),
              CustomListTitle(title: "Loyalty services"),
              SizedBox(height: 15.0),
              Container(
                  width: double.infinity,
                  height: 190,
                  child: listLoyaltyBonus())
            ],
          )
        ],
      ),
    );
  }

  Widget starWidget() {
    return FutureBuilder<dynamic>(
        future: getReview(reviewRequest),
        builder: (BuildContext context, AsyncSnapshot<dynamic> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return Container(
                alignment: Alignment.centerLeft,
                child: _getReview(snapshot.data),
              );
            }
          }
        });
  }

  Future<dynamic> getReview(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'hairSalonId': req.hairsalonId.toString()};

    var review = await APIService.getAverage('Average', queryParams);
    var avg = double.parse(review);
    return avg;
  }

  Widget listHairDresser() {
    return FutureBuilder<List<HairSalonHairDresser>>(
        future: getHairDressers(request),
        builder: (BuildContext context,
            AsyncSnapshot<List<HairSalonHairDresser>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(
                scrollDirection: Axis.horizontal,
                physics: ScrollPhysics(),
                children:
                    snapshot.data!.map((e) => hairDresserWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<HairSalonHairDresser>> getHairDressers(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'HairSalonId': req.hairsalonId.toString()};

    var hairdresser = await APIService.get('HairSalonHairDresser', queryParams);
    return hairdresser!.map((i) => HairSalonHairDresser.fromJson(i)).toList();
  }

  Widget hairDresserWidget(hairdresser) => Container(
        width: 70.0,
        margin: EdgeInsets.only(left: 10.0),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.spaceBetween,
          children: [
            InkWell(
                onTap: () {
                  Navigator.of(context).push(
                    MaterialPageRoute(
                        builder: (context) =>
                            CalendarPage(hairdresser.hairdresserId, user.applicationUserId)),
                  );
                },
                child: Column(
                  children: [
                    CircleAvatar(
                      radius: 25.0,
                      backgroundColor: Colors.blue,
                      child: SvgPicture.asset(
                        assetName,
                        color: Colors.white,
                        width: 30.0,
                      ),
                    ),
                    SizedBox(height: 7),
                    Text(
                      hairdresser.hairdresserName,
                      style:
                          TextStyle(fontSize: 10, fontWeight: FontWeight.bold),
                    ),
                  ],
                ))
          ],
        ),
      );

  Widget listLoyaltyBonus() {
    return FutureBuilder<List<LoyaltyBonus>>(
        future: getLoyaltyBonuses(loyaltyRequest),
        builder:
            (BuildContext context, AsyncSnapshot<List<LoyaltyBonus>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(child: Text('${snapshot.error}'));
            } else {
              return ListView(
                scrollDirection: Axis.horizontal,
                physics: ScrollPhysics(),
                children:
                    snapshot.data!.map((e) => loyaltyBonusWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<LoyaltyBonus>> getLoyaltyBonuses(req) async {
    Map<String, String>? queryParams = null;
    if (req != null && queryParams != "")
      queryParams = {'HairSalonId': req.hairSalonId.toString()};

    var loyalty = await APIService.get('HairSalonServiceLoyaltyBonus', queryParams);
    return loyalty!.map((i) => LoyaltyBonus.fromJson(i)).toList();

  }

  Widget loyaltyBonusWidget(loyaltyBonus) => InkWell(
        child: Container(
          margin: EdgeInsets.symmetric(vertical: 10.0),
          padding: EdgeInsets.all(15.0),
          height: 150,
          decoration: BoxDecoration(
            color: Colors.blue,
            borderRadius: BorderRadius.circular(30),
          ),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            crossAxisAlignment: CrossAxisAlignment.start,
            children: <Widget>[
              Padding(
                padding: const EdgeInsets.all(10.0),
                child: CircularPercentIndicator(
                  animation: true,
                  radius: 75.0,
                  percent: 0.0,
                  lineWidth: 5.0,
                  circularStrokeCap: CircularStrokeCap.round,
                  backgroundColor: Colors.white10,
                  progressColor: Colors.white,
                  center: Text(
                    "0%",
                    style: TextStyle(
                      fontWeight: FontWeight.bold,
                      color: Colors.white,
                    ),
                  ),
                ),
              ),
              Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: <Widget>[
                  Text(
                    loyaltyBonus.serviceName,
                    style: TextStyle(
                      fontSize: 14.0,
                      color: Colors.white,
                      fontWeight: FontWeight.w700,
                    ),
                  ),
                  Text(
                    "Bonus: " + loyaltyBonus.discount.toString() + "%",
                    style: TextStyle(
                      fontSize: 12.0,
                      color: Colors.white54,
                      fontWeight: FontWeight.bold,
                    ),
                  )
                ],
              )
            ],
          ),
        ),
        onTap: () {
          Navigator.of(context).push(
            MaterialPageRoute(builder: (context) => LoyaltyPage(loyaltyBonus)),
          );
        },
      );

  Widget _getReview(result) => RatingBar.builder(
        itemSize: 17,
        initialRating: result == null ? 0.0 : result,
        minRating: 1,
        direction: Axis.horizontal,
        allowHalfRating: true,
        itemCount: 5,
        itemPadding: EdgeInsets.symmetric(horizontal: 4.0),
        itemBuilder: (context, _) => Icon(
          Icons.star,
          color: Colors.amber,
        ),
        onRatingUpdate: (rating) {
          var respone = null;

          respone = _setRating(rating);
          if (respone != null) {
            Widget okButton = TextButton(
              child: Text("OK"),
              onPressed: () {
                Navigator.pop(context);
              },
            );
            AlertDialog alert = AlertDialog(
              title: Text("Success"),
              content: Text("You have successfully rated a salon with a rating " + rating.toString()),
              actions: [
                okButton,
              ],
            );
            showDialog(
                context: context,
                builder: (BuildContext context) {
                  return alert;
                });
          }
        },
      );
}
