// Copyright 2024 The Flutter team. All rights reserved.
// Use of this source code is governed by a BSD-style license that can be
// found in the LICENSE file.

import 'dart:async';

import 'package:flutter/foundation.dart';
import 'package:logging/logging.dart';

import '../../../data/repositories/user/user_repository.dart';
import '../../../domain/models/user/user.dart';
import '../../../utils/command.dart';
import '../../../utils/result.dart';

class HomeViewModel extends ChangeNotifier {
  HomeViewModel({
    required UserRepository userRepository,
  })  : _userRepository = userRepository {
    load = Command0(_load)..execute();
  }

  final UserRepository _userRepository;
  final _log = Logger('HomeViewModel');
  User? _user;

  late Command0 load;

  User? get user => _user;

  Future<Result> _load() async {
    try {
      final userResult = await _userRepository.getUser();
      switch (userResult) {
        case Ok<User>():
          _user = userResult.value;
          _log.fine('Loaded user');
        case Error<User>():
          _log.warning('Failed to load user', userResult.error);
      }

      return userResult;
    } finally {
      notifyListeners();
    }
  }

  
}