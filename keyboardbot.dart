import 'dart:convert';
import 'dart:io';

import 'package:schttp/schttp.dart';

main() async {
  final http = ScHttpClient();
  while (true) {
    final json = jsonDecode(await http.get(Uri.parse(
        'https://www.nbcnews.com/politics/2020-elections/president-results?format=json')));
    print('Dem: ' +
        json['bopElectoralCollege']['values']
            .firstWhere(
                (e) => e.containsKey('party') && e['party'] == 'dem')['value']
            .toString());
    print('Rep: ' +
        json['bopElectoralCollege']['values']
            .firstWhere(
                (e) => e.containsKey('party') && e['party'] == 'rep')['value']
            .toString());
    File('lol').writeAsStringSync('KEKW');
    sleep(Duration(minutes: 1));
  }
}
